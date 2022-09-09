using Microsoft.Extensions.DependencyInjection;

namespace CpmPedidos.API
{
    public class DependecyInjection
    {
        public static void Register(IServiceCollection serviceProvider)
        {
            RepositoryDependence(serviceProvider);
        }

        private static void RepositoryDependence(IServiceCollection serviceProvider)
        {
            //serviceProvider.AddScoped<IProdutoRepository, ProdutoRepository>();
            //serviceProvider.AddScoped<IPedidoRepository, PedidoRepository>();
            //serviceProvider.AddScoped<ICidadeRepository, CidadeRepository>();
        }
    }
}
