using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Evolve.Migration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace videogames
{
   
    public class Program
    {
        
        private static readonly IConfiguration Configuration;
        
        static Program()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();
            
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            MigrateDatabase();

           return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }

        private static void MigrateDatabase()
        {
            try
            {
                var cnx = new Npgsql.NpgsqlConnection( Configuration.GetConnectionString("postgres_sql"));
                var evolve = new Evolve.Evolve(cnx, msg => Log.Information(msg))
                {
                    Locations = new[] {"Resources/db"},
                    IsEraseDisabled = true,
                    MetadataTableName = "schema_version"
                };
                
                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error("Database migration failed.", ex);
                throw;
            }

        }

    }

}