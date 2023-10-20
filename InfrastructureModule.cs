using APIListaContatos.Context;
using APIListaContatos.Services;
using Microsoft.EntityFrameworkCore;

namespace APIListaContatos
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddPersistence(configuration)
                .AddServices();

            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            string sqlConnectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(sqlConnectionString));

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPessoaService, PessoasService>();
            services.AddScoped<IContatoService, ContatosService>();

            return services;
        }

    }
}
