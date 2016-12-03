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
    
    public partial class Pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido()
        {
            this.PedidosDoProduto = new HashSet<PedidosDoProduto>();
        }
    
        public int Id { get; set; }
        public bool Viagem { get; set; }
        public int ContaId { get; set; }
        public System.DateTime DataHora { get; set; }
        public int UsuarioId { get; set; }
        public bool Entregue { get; set; }
        public bool Cancelado { get; set; }
    
        public virtual Conta Conta { get; set; }
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidosDoProduto> PedidosDoProduto { get; set; }
    }
}
