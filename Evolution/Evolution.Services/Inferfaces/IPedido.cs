using System.Collections.Generic;
using System.Threading.Tasks;
using Evolution.Model;

namespace Evolution.Services.Inferfaces
{
    public interface IPedido
    {
        Task<List<E_Pedido>> GetListPedido(int PedID);
        Task<E_Pedido> CreateOrEditPedido(E_Pedido _Pedido);
        Task<string> DeletePedido(int PedID);
    }
}
