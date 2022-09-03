using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Station.Models
{
    public class DataContext:DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options):base( options)
        {
           //Database.EnsureCreated();
        }

       public DbSet<Refuelling> Refuellings { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //           .SetBasePath(Directory.GetCurrentDirectory())
        //           .AddJsonFile("appsettings.json")
        //           .Build();
        //        var connectionString = configuration.GetConnectionString("DefaultConnection");
        //        optionsBuilder.UseSqlServer(connectionString);
        //    }
        //}
    }
}