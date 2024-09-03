using Microsoft.EntityFrameworkCore;

namespace Web.Api.Database
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<ApplicationDbContext>(options => 
            //        options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("InMemoryDb"));

            return services;
        }
    }
}
