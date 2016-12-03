using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Potatotech.GestaoRestaurante.Services.DTOs
{
    public class PedidoDto
    {
        public int Mesa { get; set; }
        public List<PedidosDoProdutoDto> Produtos { get; set; }
        public bool Viagem { get; set; }
        public ContaDto Conta { get; set; }
        public int UsuarioId { get; set; }
        public bool Entregue { get; set; }
        public bool Cancelado { get; set; }
        public System.DateTime DataHora { get; set; }

    }
}