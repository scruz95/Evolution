//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Evolution.Services.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class PEDIDO
    {
        public int PedID { get; set; }
        public int PedUsu { get; set; }
        public int PedProd { get; set; }
        public decimal PedVrUnit { get; set; }
        public double PedCant { get; set; }
        public decimal PedSubTot { get; set; }
        public double PedIVA { get; set; }
        public decimal PedTotal { get; set; }
    
        public virtual PRODUCTO PRODUCTO { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}
