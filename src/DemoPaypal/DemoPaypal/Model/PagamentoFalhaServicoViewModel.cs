using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPaypal.Model
{
    public class PagamentoFalhaServicoViewModel
    {
        public Guid UsuarioId { get; set; }
        public string Mensagem { get; set; }
    }
}
