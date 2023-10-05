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
    }
}
