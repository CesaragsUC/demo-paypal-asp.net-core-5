using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPaypal.Model
{
    public class ProdutoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório.")]
        public IFormFile ImagemUpload { get; set; }
        public string Imagem { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
