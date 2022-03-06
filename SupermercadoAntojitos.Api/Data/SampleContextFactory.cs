using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SupermercadoAntojitos.Contexto.Api;
using System.IO;

namespace SupermercadoAntojitos.Api.Data
{
    /// <summary>
    /// Necesaria para poder realizar migración teniendo el contexto en otra bibliotecta de clases
    /// </summary>
    public class SampleContextFactory : IDesignTimeDbContextFactory<ServiceContext>
    {
        public ServiceContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            var builder = new DbContextOptionsBuilder<ServiceContext>();
            var connectionString = configuration.GetConnectionString("ConexionBd");
            builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("SupermercadoAntojitos.Api"));


            return new ServiceContext(builder.Options);
        }
    }
}
