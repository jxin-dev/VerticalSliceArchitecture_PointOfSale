using Web.Api.Entities.Suppliers;

namespace Web.Api.Features.Suppliers
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSupplierFeature(this IServiceCollection services)
        {
            //services.AddMediatR(cfg =>
            //{
            //    cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            //});

            services.AddScoped<ISupplierRepository, SupplierRepository>();

            return services;
        }
    }
}
