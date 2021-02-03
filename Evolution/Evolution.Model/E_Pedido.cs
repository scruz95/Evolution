using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution.Model
{
    public class E_Pedido
    {
        public int PedID { get; set; }
        public int PedUsu { get; set; }
        public int PedProd { get; set; }
        public decimal PedVrUnit { get; set; }
        public double PedCant { get; set; }
        public decimal PedSubTot { get; set; }
        public double PedIVA { get; set; }
        public decimal PedTotal { get; set; }
        public string PedProDesc { get; set; }
        public string PedUsuNombre { get; set; }

    }
}
