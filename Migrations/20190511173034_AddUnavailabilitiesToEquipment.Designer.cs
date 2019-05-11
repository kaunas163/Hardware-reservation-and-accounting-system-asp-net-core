﻿// <auto-generated />
using System;
using HardwareReservationAndAccountingSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HardwareReservationAndAccountingSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190511173034_AddUnavailabilitiesToEquipment")]
    partial class AddUnavailabilitiesToEquipment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HardwareReservationAndAccountingSystem.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<int>("EquipmentTypeId");

                    b.Property<int?>("OriginalEquipmentId");

                    b.Property<int>("Status");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentTypeId");

                    b.HasIndex("OriginalEquipmentId");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("HardwareReservationAndAccountingSystem.Models.EquipmentBundle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<int?>("OriginalEquipmentBundleId");

                    b.Property<int>("Status");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("OriginalEquipmentBundleId");

                    b.ToTable("EquipmentBundles");
                });

            modelBuilder.Entity("HardwareReservationAndAccountingSystem.Models.EquipmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsArchived");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("EquipmentTypes");
                });

            modelBuilder.Entity("HardwareReservationAndAccountingSystem.Models.EquipmentsInBundles", b =>
                {
                    b.Property<int>("EquipmentId");

                    b.Property<int>("EquipmentBundleId");

                    b.HasKey("EquipmentId", "EquipmentBundleId");

                    b.HasIndex("EquipmentBundleId");

                    b.ToTable("EquipmentsInBundles");
                });

            modelBuilder.Entity("HardwareReservationAndAccountingSystem.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("Location");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("HardwareReservationAndAccountingSystem.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<int?>("EquipmentBundleId");

                    b.Property<int?>("EquipmentId");

                    b.Property<int?>("EventId");

                    b.Property<int>("NotificationTypeId");

                    b.Property<int?>("ReservationId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EquipmentBundleId");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("EventId");

                    b.HasIndex("NotificationTypeId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("HardwareReservationAndAccountingSystem.Models.NotificationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsArchived");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("NotificationTypes");
                });

            modelBuilder.Entity("HardwareReservationAndAccountingSystem.Models.NotificationsForUsers", b =>
                {
                    b.Property<int>("NotificationId");

                    b.Property<string>("UserId");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsRead");

                    b.Property<DateTime?>("ReadOn");

                    b.HasKey("NotificationId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("NotificationsForUsers");
                });

            modelBuilder.Entity("HardwareReservationAndAccountingSystem.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("CustomerId")
                        .IsRequired();

                    b.Property<DateTime>("EndTime");

                    b.Property<int>("EquipmentBundleId");

                    b.Property<int?>("EventId");

                    b.Property<int?>("OriginalReservationId");

                    b.Property<DateTime>("StartTime");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EquipmentBundleId");

                    b.HasIndex("EventId");

                    b.HasIndex("OriginalReservationId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("HardwareReservationAndAccountingSystem.Models.Unavailability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndTime");

                    b.Property<int>("EquipmentId");

                    b.Property<bool>("IsForEverything");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.ToTable("Unavailabilities");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HardwareReservationAndAccountingSystem.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Surname")
                        .HasMaxLength(50);

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("HardwareReservationAndAccountingSystem.Models.Equipment", b =>
                {
                    b.HasOne("HardwareReservationAndAccountingSystem.Models.EquipmentType", "EquipmentType")
                        .WithMany("Equipments")
                        .HasForeignKey("EquipmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HardwareReservationAndAccountingSystem.Models.Equipment", "OriginalEquipment")
                        .WithMany()
                        .HasForeignKey("OriginalEquipmentId");
                });

            modelBuilder.Entity("HardwareReservationAndAccountingSystem.Models.EquipmentBundle", b =>
                {
                    b.HasOne("HardwareReservationAndAccountingSystem.Models.EquipmentBundle", "OriginalEquipmentBundle")
                        .WithMany()
                        .HasForeignKey("OriginalEquipmentBundleId");
                });

            modelBuilder.Entity("HardwareReservationAndAccountingSystem.Models.EquipmentsInBundles", b =>
                {
                    b.HasOne("HardwareReservationAndAccountingSystem.Models.EquipmentBundle", "EquipmentBundle")
                        .WithMany("EquipmentsInBundles")
                        .HasForeignKey("EquipmentBundleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HardwareReservationAndAccountingSystem.Models.Equipment", "Equipment")
                        .WithMany("EquipmentsInBundles")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HardwareReservationAndAccountingSystem.Models.Notification", b =>
                {
                    b.HasOne("HardwareReservationAndAccountingSystem.Models.EquipmentBundle", "EquipmentBundle")
                        .WithMany("Notifications")
                        .HasForeignKey("EquipmentBundleId");

                    b.HasOne("HardwareReservationAndAccountingSystem.Models.Equipment", "Equipment")
                        .WithMany("Notifications")
                        .HasForeignKey("EquipmentId");

                    b.HasOne("HardwareReservationAndAccountingSystem.Models.Event", "Event")
                        .WithMany("Notifications")
                        .HasForeignKey("EventId");

                    b.HasOne("HardwareReservationAndAccountingSystem.Models.NotificationType", "NotificationType")
                        .WithMany("Notifications")
                        .HasForeignKey("NotificationTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HardwareReservationAndAccountingSystem.Models.Reservation", "Reservation")
                        .WithMany("Notifications")
                        .HasForeignKey("ReservationId");
                });

            modelBuilder.Entity("HardwareReservationAndAccountingSystem.Models.NotificationsForUsers", b =>
                {
                    b.HasOne("HardwareReservationAndAccountingSystem.Models.Notification", "Notification")
                        .WithMany("NotificationsForUsers")
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HardwareReservationAndAccountingSystem.Models.ApplicationUser", "User")
                        .WithMany("NotificationsForUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HardwareReservationAndAccountingSystem.Models.Reservation", b =>
                {
                    b.HasOne("HardwareReservationAndAccountingSystem.Models.ApplicationUser", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HardwareReservationAndAccountingSystem.Models.EquipmentBundle", "EquipmentBundle")
                        .WithMany("Reservations")
                        .HasForeignKey("EquipmentBundleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HardwareReservationAndAccountingSystem.Models.Event", "Event")
                        .WithMany("Reservations")
                        .HasForeignKey("EventId");

                    b.HasOne("HardwareReservationAndAccountingSystem.Models.Reservation", "OriginalReservation")
                        .WithMany()
                        .HasForeignKey("OriginalReservationId");
                });

            modelBuilder.Entity("HardwareReservationAndAccountingSystem.Models.Unavailability", b =>
                {
                    b.HasOne("HardwareReservationAndAccountingSystem.Models.Equipment", "Equipment")
                        .WithMany("Unavailabilities")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
