﻿// <auto-generated />
using System;
using LibBiz.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace UI.Migrations
{
    [DbContext(typeof(ddContext))]
    [Migration("20231014102457_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibBiz.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AttachId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DoctorMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<string>("PatientMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientUserId")
                        .HasColumnType("int");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AttachId");

                    b.HasIndex("DoctorUserId");

                    b.HasIndex("PatientUserId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("LibBiz.Models.Attach", b =>
                {
                    b.Property<int>("AttachId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttachId"));

                    b.Property<byte[]>("FileData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AttachId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("LibBiz.Models.Photograph", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Photographs");
                });

            modelBuilder.Entity("LibBiz.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("LibBiz.Models.Doctor", b =>
                {
                    b.HasBaseType("LibBiz.Models.User");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PhotographId")
                        .HasColumnType("int");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<string>("PriceDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecializationDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecializationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("PhotographId");

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("LibBiz.Models.Patient", b =>
                {
                    b.HasBaseType("LibBiz.Models.User");

                    b.HasDiscriminator().HasValue("Patient");
                });

            modelBuilder.Entity("LibBiz.Models.Appointment", b =>
                {
                    b.HasOne("LibBiz.Models.Attach", "Attach")
                        .WithMany()
                        .HasForeignKey("AttachId");

                    b.HasOne("LibBiz.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibBiz.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attach");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("LibBiz.Models.Photograph", b =>
                {
                    b.HasOne("LibBiz.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibBiz.Models.Doctor", b =>
                {
                    b.HasOne("LibBiz.Models.Photograph", "Photograph")
                        .WithMany()
                        .HasForeignKey("PhotographId");

                    b.Navigation("Photograph");
                });
#pragma warning restore 612, 618
        }
    }
}
