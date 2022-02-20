using AutoMapper;
using Business.Interfaces.IRepositorio;
using Business.Interfaces.IService;
using DemoPaypal.Identity.Models;
using DemoPaypal.Model;
using Domain.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPaypal.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public AccountController(

            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IUsuarioRepositorio usuarioRepositorio,
            IUsuarioService usuarioService,
            IMapper mapper
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _usuarioRepositorio = usuarioRepositorio;
            _usuarioService = usuarioService;
            _mapper = mapper;
        }


        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {

            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserDTO registerUser)
        {
            if (!ModelState.IsValid) return View(registerUser);

            var user = new IdentityUser
            {
                UserName = registerUser.Name,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var usuario = new UsuarioViewModel
            {
                IdentityId = Guid.Parse(user.Id),
                Nome = user.UserName,
                Email = user.Email,
                DataCriacao = DateTime.Now,

            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);
            if (result.Succeeded)
            {
                await _usuarioService.Adicionar(_mapper.Map<Usuario>(usuario));

                await _signInManager.SignInAsync(user, false);
      
            }


            return RedirectToAction("Index", "Home");


        }


        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserDTO loginUser)
        {
            if (!ModelState.IsValid) return View(loginUser);

            var ip = HttpContext.Connection.RemoteIpAddress.ToString();

            IdentityUser user = null;
            if (!string.IsNullOrEmpty(loginUser.Email))
            {
                if (loginUser.Email.Contains("@"))
                    user = await _userManager.FindByEmailAsync(loginUser.Email);
                else
                    user = await _userManager.FindByNameAsync(loginUser.Email);

            }
            else if (!string.IsNullOrEmpty(loginUser.UserName))
            {
                user = await _userManager.FindByNameAsync(loginUser.UserName);
            }
            else
            {

                ModelState.AddModelError("Password", "The email and password is required");
                return View(loginUser);
            }


            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, loginUser.Password, false, true);

                if (result.Succeeded)
                {
                    TempData["UserId"] = user.Id;
                    return RedirectToAction("Index", "Home");
                }
                if (result.IsLockedOut)
                {
                    return View(loginUser);
                }
                return View(loginUser);

            }
            else
            {
                return View(loginUser);
            }


        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private async Task<bool> IsUserNameOrEmailExist(RegisterUserDTO loginUser)
        {
            if (!string.IsNullOrEmpty(loginUser.Name)
                && !string.IsNullOrEmpty(loginUser.Email)
                && !string.IsNullOrEmpty(loginUser.Password))
            {
                var result = await _usuarioRepositorio.GetByNameAndEmail(loginUser.Email);
                if (result != null)
                    return true;
            }
            return false;

        }


    }
}
