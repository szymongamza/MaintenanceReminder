﻿// <auto-generated />
using System;
using MaintenanceReminder.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MaintenanceReminder.Migrations
{
    [DbContext(typeof(MaintenanceReminderContext))]
    [Migration("20230301220850_InitialCreate2")]
    partial class InitialCreate2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MaintenanceReminder.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTimeOfLastMaintenance")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeOfNextMaintenance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaintainerId")
                        .HasColumnType("int");

                    b.Property<int?>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MaintainerId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Device");
                });

            modelBuilder.Entity("MaintenanceReminder.Models.Maintainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Maintainer");
                });

            modelBuilder.Entity("MaintenanceReminder.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("MaintenanceReminder.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("MaintenanceReminder.Models.Device", b =>
                {
                    b.HasOne("MaintenanceReminder.Models.Maintainer", "Maintainer")
                        .WithMany("Devices")
                        .HasForeignKey("MaintainerId");

                    b.HasOne("MaintenanceReminder.Models.Manufacturer", "Manufacturer")
                        .WithMany("Devices")
                        .HasForeignKey("ManufacturerId");

                    b.HasOne("MaintenanceReminder.Models.Place", "Place")
                        .WithMany("Devices")
                        .HasForeignKey("PlaceId");

                    b.Navigation("Maintainer");

                    b.Navigation("Manufacturer");

                    b.Navigation("Place");
                });

            modelBuilder.Entity("MaintenanceReminder.Models.Maintainer", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("MaintenanceReminder.Models.Manufacturer", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("MaintenanceReminder.Models.Place", b =>
                {
                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
