using MVCAPIdotNET_starter.Models.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MVCAPIdotNET_starter.Models.Domain.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("AppDB")
        {
        }

        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add<PluralizingTableNameConvention>();

            modelBuilder.Entity<Position>()
                .HasRequired<Subject>(a => a.Subject)
                .WithMany(e => e.Positions)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Position>()
                .HasRequired<Group>(a => a.Group)
                .WithMany(e => e.Positions)
                .WillCascadeOnDelete(false);

            /* Many to Many
               modelBuilder.Entity<Library>()
                .HasMany(e => e.Questions)
                .WithRequired(e => e.Library)
                .WillCascadeOnDelete(true);*/
        }
    }
}