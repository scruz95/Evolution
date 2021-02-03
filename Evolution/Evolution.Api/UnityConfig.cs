using Unity;
using Unity.Lifetime;
using Evolution.Services.Inferfaces;
using Evolution.Services.Services;

namespace Evolution.Api
{
    public class UnityConfig
    {
        public UnityContainer Register()
        {
            var container = new UnityContainer();
            container.RegisterType<IUsuario, UsuarioService>(new HierarchicalLifetimeManager());
            container.RegisterType<IProducto, ProductoService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPedido, PedidoService>(new HierarchicalLifetimeManager());
            return container;
        }
    }
}