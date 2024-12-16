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

        public DbSet<Casette> casettes { get; set; }
        public DbSet<ATM> atms { get; set; }
        public DbSet<User> users { get; set; }
		public DbSet<Admin> admins { get; set; }
        public DbSet<Customer> customers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Konfigurasi relasi antar tabel
			modelBuilder.Entity<User>()
				.HasOne(u => u.customer)
				.WithOne(n => n.user)
				.HasForeignKey<Customer>(n => n.user_id);

			modelBuilder.Entity<User>()
				.HasOne(u => u.admin)
				.WithOne(a => a.user)
				.HasForeignKey<Admin>(a => a.user_id);
		}
	}
}
