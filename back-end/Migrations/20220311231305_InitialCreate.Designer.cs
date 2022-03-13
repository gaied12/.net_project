﻿// <auto-generated />
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220311231305_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("API.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("number")
                        .HasColumnType("INTEGER");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("specialtyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("specialtyId");

                    b.ToTable("doctors");
                });

            modelBuilder.Entity("API.Entities.Metting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("doctorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("patientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("start")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("state")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("doctorId");

                    b.HasIndex("patientId");

                    b.ToTable("mettings");
                });

            modelBuilder.Entity("API.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("phone")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("API.Entities.Specialtyy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("specialty")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("specialtyys");
                });

            modelBuilder.Entity("API.Entities.Doctor", b =>
                {
                    b.HasOne("API.Entities.Specialtyy", "specialty")
                        .WithMany()
                        .HasForeignKey("specialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("specialty");
                });

            modelBuilder.Entity("API.Entities.Metting", b =>
                {
                    b.HasOne("API.Entities.Doctor", "doctor")
                        .WithMany()
                        .HasForeignKey("doctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Patient", "patient")
                        .WithMany()
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("doctor");

                    b.Navigation("patient");
                });
#pragma warning restore 612, 618
        }
    }
}
