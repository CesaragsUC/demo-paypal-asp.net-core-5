using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPaypal.Model
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public Guid IdentityId { get;  set; }


        public string Nome { get;  set; }

        public string Email { get;  set; }

        public DateTime DataCriacao { get; set; }
    }
}
