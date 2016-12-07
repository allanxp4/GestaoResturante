using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Potatotech.GestaoRestaurante.Dominio.Models;

namespace Potatotech.GestaoRestaurante.Services.DTOs
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public int MesaId { get; set; }
        public ICollection<PedidosDoProdutoDto> PedidosDoProduto { get; set; }
        public bool Viagem { get; set; }
        public int UsuarioId { get; set; }
        public bool Entregue { get; set; }
        public bool Cancelado { get; set; }
        public System.DateTime DataHora { get; set; }
        public ContaDto Conta { get; set; }

    }
}