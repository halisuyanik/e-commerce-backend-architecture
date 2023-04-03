using e_commerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Persistence
{
    public class DesignTimeDbContextFactory:IDesignTimeDbContextFactory<dbContext>
    {
        public dbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<dbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
