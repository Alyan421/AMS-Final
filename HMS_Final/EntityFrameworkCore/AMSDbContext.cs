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
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorHospital> DoctorHospitals { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure User Entity
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

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

            // One-to-Many: User ↔ Appointment
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.User)
                .WithMany(u => u.Appointments)
                .HasForeignKey(a => a.UserId);

            // Configure Admin Entity
            modelBuilder.Entity<Admin>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Admin>()
                .HasOne(a => a.Hospital)
                .WithMany(h => h.Admins)
                .HasForeignKey(a => a.HospitalId);

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

            // Many-to-Many: Hospital ↔ Department
            modelBuilder.Entity<HospitalDepartment>()
                .HasKey(hd => new { hd.HospitalId, hd.DepartmentId });

            modelBuilder.Entity<HospitalDepartment>()
                .HasOne(hd => hd.Hospital)
                .WithMany(h => h.HospitalDepartments)
                .HasForeignKey(hd => hd.HospitalId);

            modelBuilder.Entity<HospitalDepartment>()
                .HasOne(hd => hd.Department)
                .WithMany(d => d.HospitalDepartments)
                .HasForeignKey(hd => hd.DepartmentId);
            // Configure DoctorHospital Entity
            modelBuilder.Entity<DoctorHospital>()
                .HasKey(dh => dh.Id); // Set the Id as the primary key

            modelBuilder.Entity<DoctorHospital>()
                .Property(dh => dh.Id)
                .ValueGeneratedOnAdd(); // Ensure the Id is auto-incremented

            modelBuilder.Entity<DoctorHospital>()
                .HasOne(dh => dh.Doctor)
                .WithMany(d => d.DoctorHospitals)
                .HasForeignKey(dh => dh.DoctorId);

            modelBuilder.Entity<DoctorHospital>()
                .HasOne(dh => dh.Hospital)
                .WithMany(h => h.DoctorHospitals)
                .HasForeignKey(dh => dh.HospitalId);


            // Configure Doctor Entity
            modelBuilder.Entity<Doctor>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<Doctor>()
                .Property(d => d.DoctorName)
                .IsRequired()
                .HasMaxLength(100);

            // One-to-Many: Doctor ↔ Schedule
            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Doctor)
                .WithMany(d => d.Schedules)
                .HasForeignKey(s => s.DoctorId);

            // Configure Schedule Entity
            modelBuilder.Entity<Schedule>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Schedule>()
                .Property(s => s.ConsultationDay)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Schedule>()
                .Property(s => s.ConsultationTime)
                .IsRequired()
                .HasMaxLength(10);

            // One-to-Many: Schedule ↔ Appointment
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Schedule)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.ScheduleId);

            base.OnModelCreating(modelBuilder);
        }
    }
}