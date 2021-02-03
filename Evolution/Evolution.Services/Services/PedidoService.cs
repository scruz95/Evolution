using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Evolution.Model;
using Evolution.Services.Inferfaces;

namespace Evolution.Services.Services
{
    public class PedidoService : IPedido
    {
        private readonly Data.EVOLUTIONEntities _Conexion;

        public PedidoService(Data.EVOLUTIONEntities Conexion)
        {
            _Conexion = Conexion;
        }

        public async Task<List<E_Pedido>> GetListPedido(int PedID)
        {
            List<E_Pedido> ListaPedidos = await _Conexion.PEDIDO
                .Join(_Conexion.PRODUCTO, p => p.PedProd, pro => pro.ProID, (p, pro) => new { p, pro})
                .Join(_Conexion.USUARIO, p => p.p.PedUsu, u => u.UsuID, (p, u) => new { p, u })
                .Where(p => PedID == 0 || p.p.p.PedID == PedID)
                
                .Select(p => new E_Pedido
                {
                    PedID = p.p.p.PedID,
                    PedUsu = p.p.p.PedUsu,
                    PedProd = p.p.p.PedProd,
                    PedVrUnit = p.p.p.PedVrUnit,
                    PedCant = p.p.p.PedCant,
                    PedSubTot = p.p.p.PedSubTot,
                    PedIVA = p.p.p.PedIVA,
                    PedTotal = p.p.p.PedTotal,
                    PedProDesc = p.p.pro.ProDesc,
                    PedUsuNombre = p.u.UsuNombre
                })
                .ToListAsync();

            return ListaPedidos;
        }

        public async Task<E_Pedido> CreateOrEditPedido(E_Pedido _Pedido)
        {
            var Existe = await _Conexion.PEDIDO.SingleOrDefaultAsync(p => p.PedID == _Pedido.PedID);

            if (Existe != null)
            {
                Existe.PedVrUnit = _Pedido.PedVrUnit;
                Existe.PedCant = _Pedido.PedCant;
                Existe.PedSubTot = _Pedido.PedSubTot;
                Existe.PedIVA = _Pedido.PedIVA;
                Existe.PedTotal = _Pedido.PedTotal;

                _Conexion.Entry(Existe).State = EntityState.Modified;
            }
            else
            {
                Data.PEDIDO Pedido = new Data.PEDIDO
                {
                    PedUsu = _Pedido.PedUsu,
                    PedProd = _Pedido.PedProd,
                    PedVrUnit = _Pedido.PedVrUnit,
                    PedCant = _Pedido.PedCant,
                    PedSubTot = _Pedido.PedSubTot,
                    PedIVA = _Pedido.PedIVA,
                    PedTotal = _Pedido.PedTotal
                };

                _Conexion.PEDIDO.Add(Pedido);
            }
            _Conexion.SaveChanges();

            return (_Pedido);
        }

        public async Task<string> DeletePedido(int PedID)
        {
                var Ped = await _Conexion.PEDIDO.Where(p => p.PedID == PedID).FirstOrDefaultAsync();
                if (Ped != null)
                {
                    _Conexion.PEDIDO.Remove(Ped);
                    _Conexion.SaveChanges();
                    return "Registro Eliminado correctamente";
                }
                else
                {
                    return "No existe un registro con ese ID";
                }

        }
    }
}
