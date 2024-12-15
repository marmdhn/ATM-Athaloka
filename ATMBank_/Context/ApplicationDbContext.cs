using ATMBank_.Models;
using Microsoft.EntityFrameworkCore;

namespace ATMBank_.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            :base(options)
        {
            
        }

        public DbSet<Casette> Casettes { get; set; }
        public DbSet<ATM> ATMs { get; set; }
        public DbSet<User> Users { get; set; }
		public DbSet<Admin> Admins { get; set; }
        public DbSet<Nasabah> Nasabahs { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Konfigurasi relasi antar tabel
			modelBuilder.Entity<User>()
				.HasOne(u => u.Nasabah)
				.WithOne(n => n.User)
				.HasForeignKey<Nasabah>(n => n.UserId);

			modelBuilder.Entity<User>()
				.HasOne(u => u.Admin)
				.WithOne(a => a.User)
				.HasForeignKey<Admin>(a => a.UserId);
		}
	}
}
