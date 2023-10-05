using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Anonymous_forum.Models;

namespace Anonymous_forum.Data
{
    public class ForumContext : DbContext
    {
        public ForumContext (DbContextOptions<ForumContext> options)
            : base(options)
        {
        }

        public DbSet<Categories> Categories { get; set; } = null!;

        public DbSet<Comments> Comments { get; set; } = null!;

        public DbSet<Threads> Threads { get; set; } = null!;

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId); // Makes sure that this entity and the entities below have keys
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
        }*/
    }
}
