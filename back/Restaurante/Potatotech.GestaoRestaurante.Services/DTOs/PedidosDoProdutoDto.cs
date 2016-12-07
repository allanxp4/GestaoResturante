using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Potatotech.GestaoRestaurante.Services.DTOs
{
    public class PedidosDoProdutoDto
    {
        
        public int PedidoId { get; set; }
        public int Quantidade { get; set; }
        public string Observacoes { get; set; }
        public decimal Valor { get; set; }
        public int ProdutoId { get; set; }
        
        public virtual ProdutoDto Produto { get; set; }
    }
}