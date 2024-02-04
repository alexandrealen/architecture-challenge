using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Interfaces;
using System.Reflection;

namespace Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(
                options => options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml")));


            builder.Services.AddScoped<IFluxoDeCaixaService, FluxoDeCaixaService>();

            builder.Services.AddDbContext<FluxoDeCaixaRepository>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")), 
                ServiceLifetime.Transient);

            var migrationSuceeded = false;
            while (!migrationSuceeded)
            {
                try
                {
                    using (var scope = builder.Services.BuildServiceProvider().CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<FluxoDeCaixaRepository>();
                        dbContext.Database.Migrate();
                    }

                    migrationSuceeded = true;
                }
                catch (Exception _)
                {
                    Console.WriteLine("Aguardando inicializacao do banco de dados...");
                    Thread.Sleep(3000);
                }
            }


            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseRequestLocalization();

            app.Run();
        }
    }
}