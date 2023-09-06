using EfCore.Configurations;
using EfCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EfCore
{
    public class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlServer(connectionString: @"Data Source=DESKTOP-0MBBGDV;Initial Catalog=EfCore;Integrated Security=True");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //adding this line instead of data annotation help in seperation of concern
            //modelBuilder.Entity<Blog>().Property(m => m.Url).IsRequired();
            //new BlogEntityTypeConfigurations().Configure(modelBuilder.Entity<Blog>());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogEntityTypeConfigurations).Assembly);
            //adding model in this method to the database
            modelBuilder.Entity<AuditEntry>();
            //modelBuilder.Ignore<Post>(); //will not work as a navigation property


            //exlude table from migrations:
            modelBuilder.Entity<Blog>().ToTable("Blogs", b => b.ExcludeFromMigrations()); 

        }

        public DbSet<Blog> Blogs { get; set; }

    }
}
