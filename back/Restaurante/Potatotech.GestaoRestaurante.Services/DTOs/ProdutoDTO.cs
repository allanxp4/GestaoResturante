using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Potatotech.GestaoRestaurante.Services.DTOs
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public decimal Imposto { get; set; }
    }
}