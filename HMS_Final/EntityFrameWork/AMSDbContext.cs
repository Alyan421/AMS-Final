using HMS_Final.Models;
using Microsoft.EntityFrameworkCore;


namespace AppointmentManagementSystem.Data
{
    public class AMSDbContext : DbContext
    {
        public AMSDbContext(DbContextOptions<AMSDbContext> options)
            : base(options)
        {
        }

        // DbSets for all the entities
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<UserHospital> UserHospitals { get; set; }
        public DbSet<HospitalDepartment> HospitalDepartments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure User Entity
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id); // Primary Key

            modelBuilder.Entity<User>()
                .Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired();

            // Configure Admin Entity
            modelBuilder.Entity<Admin>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Admin>()
                .HasMany(a => a.Hospitals)
                .WithOne(h => h.Admin)
                .HasForeignKey(h => h.AdminId);

            // Configure Hospital Entity
            modelBuilder.Entity<Hospital>()
                .HasKey(h => h.Id);

            modelBuilder.Entity<Hospital>()
                .Property(h => h.Name)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Hospital>()
                .HasOne(h => h.City)
                .WithMany(c => c.Hospitals)
                .HasForeignKey(h => h.CityId);

            // Configure City Entity
            modelBuilder.Entity<City>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<City>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<City>()
                .HasOne(c => c.Country)
                .WithMany(co => co.Cities)
                .HasForeignKey(c => c.CountryId);

            // Configure Country Entity
            modelBuilder.Entity<Country>()
                .HasKey(co => co.Id);

            modelBuilder.Entity<Country>()
                .Property(co => co.CountryName)
                .IsRequired()
                .HasMaxLength(150);

            // Configure Department Entity
            modelBuilder.Entity<Department>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<Department>()
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(150);

            // Configure Many-to-Many: User ↔ Hospital
            modelBuilder.Entity<UserHospital>()
                .HasKey(uh => new { uh.UserId, uh.HospitalId }); // Composite Key

            modelBuilder.Entity<UserHospital>()
                .HasOne(uh => uh.User)
                .WithMany(u => u.UserHospitals)
                .HasForeignKey(uh => uh.UserId);

            modelBuilder.Entity<UserHospital>()
                .HasOne(uh => uh.Hospital)
                .WithMany(h => h.UserHospitals)
                .HasForeignKey(uh => uh.HospitalId);

            // Configure Many-to-Many: Hospital ↔ Department
            modelBuilder.Entity<HospitalDepartment>()
                .HasKey(hd => new { hd.HospitalId, hd.DepartmentId }); // Composite Key

            modelBuilder.Entity<HospitalDepartment>()
                .HasOne(hd => hd.Hospital)
                .WithMany(h => h.HospitalDepartments)
                .HasForeignKey(hd => hd.HospitalId);

            modelBuilder.Entity<HospitalDepartment>()
                .HasOne(hd => hd.Department)
                .WithMany(d => d.HospitalDepartments)
                .HasForeignKey(hd => hd.DepartmentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
