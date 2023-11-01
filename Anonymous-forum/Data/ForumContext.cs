using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AnonymousForum.Models;

namespace AnonymousForum.Data
{
    public class ForumContext : DbContext
    {
        public ForumContext (DbContextOptions<ForumContext> options)
            : base(options)
        {
        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Threads> Threads { get; set; }
    }
}
