//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Potatotech.GestaoRestaurante.Dominio.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PedidosDoProduto
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int PedidoId { get; set; }
        public int Quantidade { get; set; }
        public string Observacoes { get; set; }
        public decimal Valor { get; set; }
    
        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }
    }
}