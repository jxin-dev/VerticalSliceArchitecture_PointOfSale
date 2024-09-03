
using Web.Api.Entities.Products;

namespace Web.Api.Features.Products
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProductFeature(this IServiceCollection services)
        {
            //services.AddMediatR(cfg => 
            //{ 
            //    cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            //});

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
