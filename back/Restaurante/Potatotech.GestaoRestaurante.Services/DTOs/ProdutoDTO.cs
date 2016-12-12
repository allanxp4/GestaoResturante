using Potatotech.GestaoRestaurante.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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