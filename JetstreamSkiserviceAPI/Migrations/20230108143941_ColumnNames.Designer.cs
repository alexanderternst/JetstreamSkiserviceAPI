﻿// <auto-generated />
using System;
using JetstreamSkiserviceAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JetstreamSkiserviceAPI.Migrations
{
    [DbContext(typeof(RegistrationContext))]
    [Migration("20230108143941_ColumnNames")]
    partial class ColumnNames
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JetstreamSkiserviceAPI.Models.Priority", b =>
                {
                    b.Property<int>("Priority_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Priority_id"), 1L, 1);

                    b.Property<string>("Priority_name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Priority_id");

                    b.ToTable("Priority");
                });

            modelBuilder.Entity("JetstreamSkiserviceAPI.Models.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("Create_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("Pickup_date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Priority_id")
                        .HasColumnType("int");

                    b.Property<int?>("Service_id")
                        .HasColumnType("int");

                    b.Property<int?>("Status_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Priority_id");

                    b.HasIndex("Service_id");

                    b.HasIndex("Status_id");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("JetstreamSkiserviceAPI.Models.Service", b =>
                {
                    b.Property<int>("Service_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Service_id"), 1L, 1);

                    b.Property<string>("Service_name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Service_id");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("JetstreamSkiserviceAPI.Models.Status", b =>
                {
                    b.Property<int>("Status_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Status_id"), 1L, 1);

                    b.Property<string>("Status_name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Status_id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("JetstreamSkiserviceAPI.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Counter")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Username")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JetstreamSkiserviceAPI.Models.Registration", b =>
                {
                    b.HasOne("JetstreamSkiserviceAPI.Models.Priority", "Priority")
                        .WithMany("Registrations")
                        .HasForeignKey("Priority_id");

                    b.HasOne("JetstreamSkiserviceAPI.Models.Service", "Service")
                        .WithMany("Registrations")
                        .HasForeignKey("Service_id");

                    b.HasOne("JetstreamSkiserviceAPI.Models.Status", "Status")
                        .WithMany("Registrations")
                        .HasForeignKey("Status_id");

                    b.Navigation("Priority");

                    b.Navigation("Service");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("JetstreamSkiserviceAPI.Models.Priority", b =>
                {
                    b.Navigation("Registrations");
                });

            modelBuilder.Entity("JetstreamSkiserviceAPI.Models.Service", b =>
                {
                    b.Navigation("Registrations");
                });

            modelBuilder.Entity("JetstreamSkiserviceAPI.Models.Status", b =>
                {
                    b.Navigation("Registrations");
                });
#pragma warning restore 612, 618
        }
    }
}