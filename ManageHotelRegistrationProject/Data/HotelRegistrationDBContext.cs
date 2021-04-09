using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class HotelRegistrationDBContext : IdentityDbContext<User, IdentityRole, string>
    {
        //public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public HotelRegistrationDBContext()
        {

        }
        public HotelRegistrationDBContext(DbContextOptions<HotelRegistrationDBContext> options) : base (options)
        {

        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(x => x.Reservations)
                .WithMany(y => y.Clients)
                .HasForeignKey(p => p.ReservationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Room>()
                .HasOne(room => room.Reservation)
                .WithOne(p => p.Room)
                .HasForeignKey<Reservation>(e => e.RoomId);
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if(!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=HotelRegistrationDb; Integrated Security = true;");
                dbContextOptionsBuilder.UseLazyLoadingProxies();
            }
        }
    }
}
