using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Anonymous_forum.Models;

namespace Anonymous_forum.Data
{
    public class Anonymous_forumContext : DbContext
    {
        public Anonymous_forumContext (DbContextOptions<Anonymous_forumContext> options)
            : base(options)
        {
        }

        public DbSet<Anonymous_forum.Models.Categories> Categories { get; set; } = default!;

        public DbSet<Anonymous_forum.Models.Comments>? Comments { get; set; }

        public DbSet<Anonymous_forum.Models.Threads>? Threads { get; set; }
    }
}
