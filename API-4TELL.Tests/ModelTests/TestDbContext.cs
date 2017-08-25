using API_4TELL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_4TELL.Tests.ModelTests
{
    public class TestDbContext : ApplicationContext
    {
        public override DbSet<Product> Products { get; set; }
        public override DbSet<Category> Categories { get; set; }

        // Change connection string for local use.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=DESKTOP-GC3DC7B\\SQLEXPRESS;Database=4TELLAPITest;integrated security = True");
        }
    }
}
