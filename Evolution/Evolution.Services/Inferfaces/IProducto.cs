using System.Collections.Generic;
using System.Threading.Tasks;
using Evolution.Model;

namespace Evolution.Services.Inferfaces
{
    public interface IProducto
    {
        Task<List<E_Producto>> GetListProducto(int ProID);
        Task<E_Producto> CreateOrEditProducto(E_Producto _Producto);
        Task<string> DeleteProducto(int ProID);
    }
}
