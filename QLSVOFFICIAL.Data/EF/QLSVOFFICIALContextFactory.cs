using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QLSVOFFICIAL.Data.EF
{
    public class QLSVOFFICIALContextFactory : IDesignTimeDbContextFactory<QLSVContext>
    {
        public QLSVContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetings.json")
                .Build();

            var connnectionString = configuration.GetConnectionString("QLSVDbContext");

            var optionsBuilder = new DbContextOptionsBuilder<QLSVContext>();
            optionsBuilder.UseSqlServer(connnectionString);

            return new QLSVContext(optionsBuilder.Options);
        }
    }
}
