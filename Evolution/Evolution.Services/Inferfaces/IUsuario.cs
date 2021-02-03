using System.Collections.Generic;
using System.Threading.Tasks;
using Evolution.Model;

namespace Evolution.Services.Inferfaces
{
    public interface IUsuario
    {
        Task<List<E_Usuario>> GetListUsuario(int UsuID, string UsuNombre);
        Task<E_Usuario> CreateOrEditUsuario(E_Usuario _Usuario);
        Task<string> DeleteUsuario(int UsuID);
    }
}
