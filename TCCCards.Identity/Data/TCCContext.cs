using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCCards.Identity.Data.Configuration;

namespace TCCCards.Identity.Data
{
    public class TCCContext : DbContext
    {
        public TCCContext(DbContextOptions options)
            : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());

        }
        
        public virtual DbSet<User> User { get; set; }
    }
}
