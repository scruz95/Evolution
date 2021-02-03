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
    public class ProductoService : IProducto
    {
        private readonly Data.EVOLUTIONEntities _Conexion;

        public ProductoService(Data.EVOLUTIONEntities Conexion)
        {
            _Conexion = Conexion;
        }

        public async Task<List<E_Producto>> GetListProducto(int ProID)
        {
            List<E_Producto> ListaProductos = await _Conexion.PRODUCTO
                .Where(u => ProID == 0 || u.ProID == ProID)
                .Select(u => new E_Producto
                {
                    ProID = u.ProID,
                    ProDesc = u.ProDesc,
                    ProValor = u.ProValor
                })
                .ToListAsync();

            return ListaProductos;
        }

        public async Task<E_Producto> CreateOrEditProducto(E_Producto _Producto)
        {
            var Existe = await _Conexion.PRODUCTO.SingleOrDefaultAsync(p => p.ProID == _Producto.ProID);

            if (Existe != null)
            {
                Existe.ProDesc = _Producto.ProDesc;
                Existe.ProValor = _Producto.ProValor;

                _Conexion.Entry(Existe).State = EntityState.Modified;
            }
            else
            {
                Data.PRODUCTO Producto = new Data.PRODUCTO
                {
                    ProDesc = _Producto.ProDesc,
                    ProValor = _Producto.ProValor
                };

                _Conexion.PRODUCTO.Add(Producto);
            }
            _Conexion.SaveChanges();

            return (_Producto);
        }

        public async Task<string> DeleteProducto(int ProID)
        {
            var Resultado = await _Conexion.PEDIDO.SingleOrDefaultAsync(p => p.PedProd == ProID);
            if (Resultado == null)
            {
                var Pro = await _Conexion.PRODUCTO.Where(p => p.ProID == ProID).FirstOrDefaultAsync();
                if (Pro != null)
                {
                    _Conexion.PRODUCTO.Remove(Pro);
                    _Conexion.SaveChanges();
                    return "Registro Eliminado correctamente";
                }
                else
                {
                    return "No existe un registro con ese ID";
                }

            }
            else
            {
                return "No se puede eliminar el registro, ya que el prodcuto tiene asociado un pedido'";
            }
        }
    }
}
