using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreV2
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(connectionString: @"Data Source=DESKTOP-0MBBGDV;Initial Catalog=EfCoreV2;Integrated Security=True");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasOne(x => x.BlogImage).WithOne(i => i.Blog).HasForeignKey<BlogImage>(f => f.BlogFk);



        }
        public DbSet<Blog> Blogs { get; set; } 

    }
    public class Blog
    {
        public int Id { get; set; }
        [Required, MaxLength(1000)]
        public string Url { get; set; }
        public BlogImage BlogImage { get; set; }
    }
    public class BlogImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [Required, MaxLength(250)]
        public string Caption { get; set; }
        public int BlogFk { get; set; }
        public Blog Blog { get; set; }

    }
}

