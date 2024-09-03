using Web.Api.Entities.Categories;

namespace Web.Api.Features.Categories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCategoryFeature(this IServiceCollection services)
        {
            //services.AddMediatR(cfg =>
            //{
            //    cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            //});
            services.AddScoped<ICategoryRepository, CategoryRepository>();  
            return services;
        }
    }
}
