﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace autokolcsonzo.Models;

public partial class KolcsonzoContext : DbContext
{
    public KolcsonzoContext()
    {
    }

    public KolcsonzoContext(DbContextOptions<KolcsonzoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Rent> Rents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=kolcsonzo;user=root;password=;sslmode=none;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cars");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Evjarat).HasColumnType("date");
            entity.Property(e => e.Marka).HasMaxLength(255);
            entity.Property(e => e.Model).HasMaxLength(255);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("customers");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Rent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("rents");

            entity.HasIndex(e => e.CarId, "Car_id");

            entity.HasIndex(e => e.CustomerId, "Customer_id");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.CarId)
                .HasMaxLength(36)
                .HasColumnName("Car_id");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(36)
                .HasColumnName("Customer_id");
            entity.Property(e => e.End).HasColumnType("date");
            entity.Property(e => e.Start).HasColumnType("date");

            entity.HasOne(d => d.Car).WithMany(p => p.Rents)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("rents_ibfk_1");

            entity.HasOne(d => d.Customer).WithMany(p => p.Rents)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("rents_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
