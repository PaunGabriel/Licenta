using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spinit.Models
{
    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    //{
    //    public AppDbContext CreateDbContext(string[] args)
    //    {
    //        IConfigurationRoot configuration = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json")
    //            .Build();
    //        var builder = new DbContextOptionsBuilder<AppDbContext>();
    //        var connectionString = configuration.GetConnectionString("MyAppCS");
    //        builder.UseSqlServer(connectionString);
    //        return new AppDbContext(builder.Options);
    //    }
    //}
}
