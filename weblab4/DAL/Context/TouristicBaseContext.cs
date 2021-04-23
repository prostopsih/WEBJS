using DAL.Abstractions.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class TouristicBaseContext : DbContext
    {
        public TouristicBaseContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Tour)
                .WithMany(t => t.Tickets)
                .HasForeignKey(t => t.TourId);
        }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Media> Medias { get; set; }
    }
}
