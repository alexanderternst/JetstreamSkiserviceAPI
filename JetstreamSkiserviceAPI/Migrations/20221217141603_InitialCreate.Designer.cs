// <auto-generated />
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
    [Migration("20221217141603_InitialCreate")]
    partial class InitialCreate
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
                    b.Property<int>("priority_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("priority_id"), 1L, 1);

                    b.Property<string>("priority_name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("priority_id");

                    b.ToTable("Priority");
                });

            modelBuilder.Entity("JetstreamSkiserviceAPI.Models.Registration", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("create_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("pickup_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("priority_id")
                        .HasColumnType("int");

                    b.Property<int>("service_id")
                        .HasColumnType("int");

                    b.Property<int>("status_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("priority_id");

                    b.HasIndex("service_id");

                    b.HasIndex("status_id");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("JetstreamSkiserviceAPI.Models.Service", b =>
                {
                    b.Property<int>("service_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("service_id"), 1L, 1);

                    b.Property<string>("service_name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("service_id");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("JetstreamSkiserviceAPI.Models.Status", b =>
                {
                    b.Property<int>("status_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("status_id"), 1L, 1);

                    b.Property<string>("status_name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("status_id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("JetstreamSkiserviceAPI.Models.Users", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("user_id"), 1L, 1);

                    b.Property<int>("counter")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("user_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JetstreamSkiserviceAPI.Models.Registration", b =>
                {
                    b.HasOne("JetstreamSkiserviceAPI.Models.Priority", "Priority")
                        .WithMany("registrations")
                        .HasForeignKey("priority_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JetstreamSkiserviceAPI.Models.Service", "Service")
                        .WithMany("registrations")
                        .HasForeignKey("service_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JetstreamSkiserviceAPI.Models.Status", "Status")
                        .WithMany("registrations")
                        .HasForeignKey("status_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Priority");

                    b.Navigation("Service");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("JetstreamSkiserviceAPI.Models.Priority", b =>
                {
                    b.Navigation("registrations");
                });

            modelBuilder.Entity("JetstreamSkiserviceAPI.Models.Service", b =>
                {
                    b.Navigation("registrations");
                });

            modelBuilder.Entity("JetstreamSkiserviceAPI.Models.Status", b =>
                {
                    b.Navigation("registrations");
                });
#pragma warning restore 612, 618
        }
    }
}
