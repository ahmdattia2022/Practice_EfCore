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
            //modelBuilder.Entity<Blog>().ToTable("Blogs", b => b.ExcludeFromMigrations()); 
            //modelBuilder.Entity<Blog>().Ignore(b => b.Posts);
            //modelBuilder.Entity<Blog>(p =>
            //{
            //    p.Property(b => b.Posts).HasColumnType("nvarchar(250)").HasMaxLength(250);
            //});

            modelBuilder.Entity<Post>().HasKey(x => x.BookKey).HasName("PK_BookKey");
            modelBuilder.Entity<Post>().Property(x => x.CreatedOn).HasDefaultValueSql("GETDATE()");


            //Computed column in author entity
            modelBuilder.Entity<Author>().Property(x => x.DisplayName).HasComputedColumnSql("[FirstName] + ',' + [LastName]");
            modelBuilder.Entity<Blog>().HasMany(x => x.Posts).WithOne(x => x.Blog);
            //Many to Many relationship
            modelBuilder.Entity<Post>().HasMany(x => x.Tags).WithMany(x => x.Posts)
                .UsingEntity<PostTag>(
                      z => z
                        .HasOne(p => p.Tag)
                        .WithMany(t => t.PostTags)
                        .HasForeignKey(f => f.TagId),
                      zz => zz
                        .HasOne(t => t.Post)
                        .WithMany(f => f.PostTags)
                        .HasForeignKey(ff => ff.PostId),
                      cmp =>
                      {
                          cmp.Property(pt => pt.AddedOn).HasDefaultValueSql("GETDATE()");
                          cmp.HasKey(key => new { key.TagId, key.PostId });
                      }

                ) ;

        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
