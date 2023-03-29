//Scaffold-DbContext "Data Source=.\SQLEXPRESS;Initial Catalog=SilvershotDB;Integrated Security=True;TrustServerCertificate=True;User ID=melich;Password=11;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DataModels
namespace SilvershotCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}