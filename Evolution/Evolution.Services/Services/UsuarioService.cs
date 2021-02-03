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
    public class UsuarioService : IUsuario
    {
        private readonly Data.EVOLUTIONEntities _Conexion;

        public UsuarioService(Data.EVOLUTIONEntities Conexion)
        {
            _Conexion = Conexion;
        }

        public async Task<List<E_Usuario>> GetListUsuario(int UsuID, string UsuNombre)
        {
            List<E_Usuario> ListaUsuarios = await _Conexion.USUARIO
                .Where(u => UsuID == 0 || u.UsuID == UsuID)
                .Where(u => UsuNombre == "" || UsuNombre == null || u.UsuNombre == UsuNombre)
                .Select(u => new E_Usuario
                {
                    UsuID = u.UsuID,
                    UsuNombre = u.UsuNombre,
                    UsuPass = u.UsuPass
                })
                .ToListAsync();

            return ListaUsuarios;
        }

        public async Task<E_Usuario> CreateOrEditUsuario(E_Usuario _Usuario)
        {
            var Existe = await _Conexion.USUARIO.SingleOrDefaultAsync(u => u.UsuID == _Usuario.UsuID);

            if(Existe != null)
            {
                Existe.UsuNombre = _Usuario.UsuNombre;
                Existe.UsuPass = _Usuario.UsuPass;

                _Conexion.Entry(Existe).State = EntityState.Modified;
            }
            else
            {
                Data.USUARIO Usuario = new Data.USUARIO
                {
                    UsuNombre = _Usuario.UsuNombre,
                    UsuPass = _Usuario.UsuPass
                };

                _Conexion.USUARIO.Add(Usuario);
            }
            _Conexion.SaveChanges();

            return (_Usuario);
        }

        public async Task<string> DeleteUsuario(int UsuID)
        {
            var Resultado = await _Conexion.PEDIDO.SingleOrDefaultAsync(p => p.PedUsu == UsuID);
            if (Resultado == null)
            {
                var Usu = await _Conexion.USUARIO.Where(p => p.UsuID == UsuID).FirstOrDefaultAsync();
                if (Usu != null)
                {
                    _Conexion.USUARIO.Remove(Usu);
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
                return "No se puede eliminar el registro, ya que el usuario tiene asociada un pedido'";
            }
        }
    }
}
