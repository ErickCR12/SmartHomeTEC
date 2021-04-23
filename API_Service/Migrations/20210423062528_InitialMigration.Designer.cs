﻿// <auto-generated />
using API_Service.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API_Service.Migrations
{
    [DbContext(typeof(SmartHomeDbContext))]
    [Migration("20210423062528_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("API_Service.Models.Device", b =>
                {
                    b.Property<int>("SerialNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DeviceTypeName")
                        .HasColumnType("text");

                    b.Property<int>("ElectricUsage")
                        .HasColumnType("integer");

                    b.HasKey("SerialNumber");

                    b.HasIndex("DeviceTypeName");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("API_Service.Models.DeviceType", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("WarrantyMonths")
                        .HasColumnType("integer");

                    b.HasKey("Name");

                    b.ToTable("DeviceTypes");
                });

            modelBuilder.Entity("API_Service.Models.Device", b =>
                {
                    b.HasOne("API_Service.Models.DeviceType", "DeviceType")
                        .WithMany("Devices")
                        .HasForeignKey("DeviceTypeName");

                    b.Navigation("DeviceType");
                });

            modelBuilder.Entity("API_Service.Models.DeviceType", b =>
                {
                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
