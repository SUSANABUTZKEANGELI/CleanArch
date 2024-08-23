using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CleanArch.Infrastructure
{
    public class ContextoFactory : IDesignTimeDbContextFactory<Contexto>
    {
        public Contexto CreateDbContext(string[] args)
        {
            // Ajuste o caminho base para o diretório do projeto CleanArch.API
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\CleanArch.API");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<Contexto>();
            var connectionString = configuration.GetConnectionString("MinhaConexao");
            optionsBuilder.UseSqlServer(connectionString);

            return new Contexto(optionsBuilder.Options);
        }
    }
}