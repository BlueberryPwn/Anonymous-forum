using Microsoft.EntityFrameworkCore;

namespace Anonymous_forum.Models
{
    public class ForumContext : DbContext
    {
        public ForumContext()
        {
        }

        public ForumContext(DbContextOptions<ForumContext> options)
            : base(options)
        {

        }

        public DbSet<Categories> Categories { get; set; } = null!;
        public DbSet<Comments> Comments { get; set; } = null!;
        public DbSet<Threads> Threads { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId); // Makes sure that this entity & all other entities have keys
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.CommentId);
            });

            modelBuilder.Entity<Threads>(entity =>
            {
                entity.HasKey(e => e.ThreadId);
            });

            OnModelCreating(modelBuilder);
        }
    }
}
