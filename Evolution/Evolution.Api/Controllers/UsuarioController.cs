using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Evolution.Model;
using Evolution.Services.Inferfaces;


namespace Evolution.Api.Controllers
{
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : ApiController
    {
        public readonly IUsuario _Usuario;

        public UsuarioController(IUsuario usuario)
        {
            _Usuario = usuario;
        }

        [HttpGet]
        [Route("ListaUsuarios")]
        public async Task<IHttpActionResult> GetListUsuarios(int UsuID, string UsuNombre)
        {
            try
            {
                return Json(await _Usuario.GetListUsuario(UsuID, UsuNombre));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("AgregarModificarUsuario")]
        public async Task<IHttpActionResult> PostCreateOrEditUsuario(E_Usuario ModelUsuario)
        {
            try
            {
                return Json(await _Usuario.CreateOrEditUsuario(ModelUsuario));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("EliminarUsuario")]
        public async Task<IHttpActionResult> DeleteUsuario(int Id)
        {
            try
            {
                return Json(await _Usuario.DeleteUsuario(Id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}