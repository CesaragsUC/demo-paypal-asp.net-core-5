using Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Usuario : Entity
    {
        public Guid IdentityId { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }

        public DateTime DataCriacao { get; set; }

    }
}
