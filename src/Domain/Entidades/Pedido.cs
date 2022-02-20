using Domain.DomainObjects;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Entidades
{
    public class Pedido : Entity
    {
        public Guid UsuarioId { get; set; }
        public Guid ProdutoId { get; set; }
        public DateTime DataCriacao { get; set; }

        public DateTime DataPagamento { get; set; }

        public string OrderPaypalId { get; set; }

        public string PayerId { get; set; }
        public string PayerName { get; set; }
        public string PayerEmail { get; set; }
        public string Status { get; set; }
        public string LinkOrder { get; set; }
        public string LinkSelfOrder { get; set; }

        public string ProdutoNome { get; set; }
        public string Descricao { get; set; }
        public string NomeUsuario { get; set; }

        public decimal Preco { get; set; }

        public bool IsCompleted { get; set; }
        public bool Pago { get; set; }

        //EF core 1 : N
        public ICollection<Produto> Produtos { get; set; }


        //EF core 1 : 1
        public Usuario Usuario { get; set; }
    }
}
