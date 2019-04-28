using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HardwareReservationAndAccountingSystem.Models;

namespace HardwareReservationAndAccountingSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EquipmentsInBundles>()
                .HasKey(e => new { e.EquipmentId, e.EquipmentBundleId });

        //     modelBuilder.Entity<EquipmentsInBundles>()
        //         .HasOne(pt => pt.Equipment)
        //         .WithMany(p => p.EquipmentsInBundles)
        //         .HasForeignKey(pt => pt.EquipmentId);

        //     modelBuilder.Entity<EquipmentsInBundles>()
        //         .HasOne(pt => pt.EquipmentBundle)
        //         .WithMany(t => t.EquipmentsInBundles)
        //         .HasForeignKey(pt => pt.EquipmentBundleId);
        }

        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentBundle> EquipmentBundles { get; set; }
        public DbSet<EquipmentsInBundles> EquipmentsInBundles { get; set; }
    }
}
