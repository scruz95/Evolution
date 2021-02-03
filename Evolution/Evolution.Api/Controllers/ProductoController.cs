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
    [RoutePrefix("api/Prodcuto")]
    public class ProductoController : ApiController
    {
        public readonly IProducto _Producto;

        public ProductoController(IProducto producto)
        {
            _Producto = producto;
        }

        [HttpGet]
        [Route("ListaProductos")]
        public async Task<IHttpActionResult> GetListProductos(int ProID)
        {
            try
            {
                return Json(await _Producto.GetListProducto(ProID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("AgregarModificarProducto")]
        public async Task<IHttpActionResult> PostCreateOrEditProducto(E_Producto ModelProducto)
        {
            try
            {
                return Json(await _Producto.CreateOrEditProducto(ModelProducto));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("EliminarProducto")]
        public async Task<IHttpActionResult> DeleteProducto(int Id)
        {
            try
            {
                return Json(await _Producto.DeleteProducto(Id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}