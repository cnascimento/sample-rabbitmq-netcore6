using Microsoft.EntityFrameworkCore;

namespace RabbitMqProductAPI.Data
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger logger = loggerFactory.CreateLogger("Migration");

            using (var scope = host.Services.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<DbContextClass>())
                {
                    var tentativas = 1;
                    var erroMigrations = true;
                    do
                    {
                        try
                        {
                            logger.LogInformation($"Executando o migrations, tentativa {tentativas}.");
                            context.Database.Migrate();

                            erroMigrations = false;
                            logger.LogInformation($"Migrations executado com sucesso!");
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, "Erro ao executar o migrations.");
                            tentativas++;
                            Thread.Sleep(3000);

                            if (tentativas > 3)
                                erroMigrations = false;
                        }
                    }
                    while(erroMigrations);
                }
            }

            return host;
        }
    }
}