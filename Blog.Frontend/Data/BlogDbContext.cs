using System;
using Microsoft.EntityFrameworkCore;
using Blog.Domain;

namespace Blog.Frontend.Data
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public BlogDbContext(
            DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .Property(p => p.Status)
                .HasConversion(
                    e => e.ToString(),
                    e => (PostStatus) Enum.Parse(typeof(PostStatus), e));

            //modelBuilder.Entity<Tag>(t =>
            //{
            //    t.Property(p => p.Id).ValueGeneratedNever();
            //    t.Property(t => t.TagName);
            //});
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
