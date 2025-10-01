
// ctrl + k + c to quickly  comment out
// ctrl + k + u to quickly uncomment 
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;
//using flightandticketproject.Data;
//using System.IO;

//namespace flightandticketproject
//{
//    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
//    {
//        public ApplicationDbContext CreateDbContext(string[] args)
//        {
//            // Build configuration manually
//            IConfigurationRoot configuration = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory())
//                .AddJsonFile("appsettings.Development.json") // or "appsettings.json" if needed
//                .Build();

//            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
//            var connectionString = configuration.GetConnectionString("DefaultConnection");

//            builder.UseNpgsql(connectionString);

//            return new ApplicationDbContext(builder.Options);
//        }
//    }
//}