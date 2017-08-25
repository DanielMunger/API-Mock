using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API_4TELL.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {

        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
        // Change connection string for local use.
            options.UseSqlServer(@"Server=DESKTOP-GC3DC7B\SQLEXPRESS;Database=4TELLAPI;integrated security=True;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
