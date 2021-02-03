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
    [RoutePrefix("api/Pedido")]
    public class PedidoController : ApiController
    {
        public readonly IPedido _Pedido;

        public PedidoController(IPedido pedido)
        {
            _Pedido = pedido;
        }

        [HttpGet]
        [Route("ListaPedido")]
        public async Task<IHttpActionResult> GetListPedido(int PedID)
        {
            try
            {
                return Json(await _Pedido.GetListPedido(PedID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("AgregarModificarPedido")]
        public async Task<IHttpActionResult> PostCreateOrEditPedido(E_Pedido ModelPedido)
        {
            try
            {
                return Json(await _Pedido.CreateOrEditPedido(ModelPedido));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("EliminarPedido")]
        public async Task<IHttpActionResult> DeletePedido(int Id)
        {
            try
            {
                return Json(await _Pedido.DeletePedido(Id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}