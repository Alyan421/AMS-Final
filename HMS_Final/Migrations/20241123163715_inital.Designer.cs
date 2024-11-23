﻿// <auto-generated />
using System;
using AppointmentManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HMS_Final.Migrations
{
    [DbContext(typeof(AMSDbContext))]
    [Migration("20241123163715_inital")]
    partial class inital
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HMS_Final.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("HMS_Final.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("HMS_Final.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("HMS_Final.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("HMS_Final.Models.Hospital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("ContactInfo")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("CityId");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("HMS_Final.Models.HospitalDepartment", b =>
                {
                    b.Property<int>("HospitalId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.HasKey("HospitalId", "DepartmentId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("HospitalDepartments");
                });

            modelBuilder.Entity("HMS_Final.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<long>("OTP")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("OTPExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResendCount")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HMS_Final.Models.UserHospital", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("HospitalId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("UserId", "HospitalId");

                    b.HasIndex("HospitalId");

                    b.ToTable("UserHospitals");
                });

            modelBuilder.Entity("HMS_Final.Models.City", b =>
                {
                    b.HasOne("HMS_Final.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("HMS_Final.Models.Hospital", b =>
                {
                    b.HasOne("HMS_Final.Models.Admin", "Admin")
                        .WithMany("Hospitals")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HMS_Final.Models.City", "City")
                        .WithMany("Hospitals")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("City");
                });

            modelBuilder.Entity("HMS_Final.Models.HospitalDepartment", b =>
                {
                    b.HasOne("HMS_Final.Models.Department", "Department")
                        .WithMany("HospitalDepartments")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HMS_Final.Models.Hospital", "Hospital")
                        .WithMany("HospitalDepartments")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Hospital");
                });

            modelBuilder.Entity("HMS_Final.Models.UserHospital", b =>
                {
                    b.HasOne("HMS_Final.Models.Hospital", "Hospital")
                        .WithMany("UserHospitals")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HMS_Final.Models.User", "User")
                        .WithMany("UserHospitals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospital");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HMS_Final.Models.Admin", b =>
                {
                    b.Navigation("Hospitals");
                });

            modelBuilder.Entity("HMS_Final.Models.City", b =>
                {
                    b.Navigation("Hospitals");
                });

            modelBuilder.Entity("HMS_Final.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("HMS_Final.Models.Department", b =>
                {
                    b.Navigation("HospitalDepartments");
                });

            modelBuilder.Entity("HMS_Final.Models.Hospital", b =>
                {
                    b.Navigation("HospitalDepartments");

                    b.Navigation("UserHospitals");
                });

            modelBuilder.Entity("HMS_Final.Models.User", b =>
                {
                    b.Navigation("UserHospitals");
                });
#pragma warning restore 612, 618
        }
    }
}
