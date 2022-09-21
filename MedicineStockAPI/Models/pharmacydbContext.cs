using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MedicineStockAPI.Models
{
    public partial class pharmacydbContext : DbContext
    {
        public pharmacydbContext()
        {
        }

        public pharmacydbContext(DbContextOptions<pharmacydbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Medicinedemand> Medicinedemands { get; set; } = null!;
        public virtual DbSet<Medicinestock> Medicinestocks { get; set; } = null!;
        public virtual DbSet<Pharmacymedicinesupply> Pharmacymedicinesupplies { get; set; } = null!;
        public virtual DbSet<Repschedule> Repschedules { get; set; } = null!;
        public virtual DbSet<VuDemandsupply> VuDemandsupplies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-VKVQK92\\SQLEXPRESS;Database=pharmacydb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicinedemand>(entity =>
            {
                entity.ToTable("medicinedemand");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Medicine)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medicinestock>(entity =>
            {
                entity.ToTable("medicinestock");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ChemicalComposition)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfExpiry).HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TargetAilment)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pharmacymedicinesupply>(entity =>
            {
                entity.ToTable("pharmacymedicinesupply");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.MedicineName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PharmacyName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Repschedule>(entity =>
            {
                entity.ToTable("repschedule");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DateofMeeting).HasColumnType("date");

                entity.Property(e => e.DoctorContactNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DoctorName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Medicine)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MeetingSlot)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RepName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TreatingAilment)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VuDemandsupply>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VU_demandsupply");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Medicine)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
