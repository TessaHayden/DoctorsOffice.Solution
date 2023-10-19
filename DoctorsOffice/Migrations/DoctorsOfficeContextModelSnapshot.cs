﻿// <auto-generated />
using DoctorsOffice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoctorOffice.Migrations
{
    [DbContext(typeof(DoctorsOfficeContext))]
    partial class DoctorsOfficeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DoctorsOffice.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DoctorName")
                        .HasColumnType("longtext");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("DoctorsOffice.Models.DoctorSpecialty", b =>
                {
                    b.Property<int>("DoctorSpecialtyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("SpecialtyId")
                        .HasColumnType("int");

                    b.HasKey("DoctorSpecialtyId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("SpecialtyId");

                    b.ToTable("DoctorSpecialties");
                });

            modelBuilder.Entity("DoctorsOffice.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("PatientName")
                        .HasColumnType("longtext");

                    b.HasKey("PatientId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("DoctorsOffice.Models.Specialty", b =>
                {
                    b.Property<int>("SpecialtyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("SpecialtyName")
                        .HasColumnType("longtext");

                    b.HasKey("SpecialtyId");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("DoctorsOffice.Models.DoctorSpecialty", b =>
                {
                    b.HasOne("DoctorsOffice.Models.Doctor", "Doctor")
                        .WithMany("JoinEntities")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorsOffice.Models.Specialty", "Specialty")
                        .WithMany("JoinEntities")
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("DoctorsOffice.Models.Patient", b =>
                {
                    b.HasOne("DoctorsOffice.Models.Doctor", "Doctors")
                        .WithMany("Patients")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("DoctorsOffice.Models.Doctor", b =>
                {
                    b.Navigation("JoinEntities");

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("DoctorsOffice.Models.Specialty", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
