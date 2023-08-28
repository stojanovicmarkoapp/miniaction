using Microsoft.EntityFrameworkCore;
using Miniaction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.DataAccess
{
    public class MiniactionContext : DbContext
    {
        public MiniactionContext()
        {

        }
        public MiniactionContext(DbContextOptions o) : base(o)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MiniactionContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = localhost; Initial Catalog = Miniaction; Integrated Security = true");
        }
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Network> Networks { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PG> PGs { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Grant> Grants { get; set; }
        public DbSet<Serial> Serials { get; set; }
        public DbSet<Star> Stars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TrackEntry> TrackEntries { get; set; }
    }
}
