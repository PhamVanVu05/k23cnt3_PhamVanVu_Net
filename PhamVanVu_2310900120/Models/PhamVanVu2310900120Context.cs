using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PhamVanVu_2310900120.Models;

public partial class PhamVanVu2310900120Context : DbContext
{
    public PhamVanVu2310900120Context()
    {
    }

    public PhamVanVu2310900120Context(DbContextOptions<PhamVanVu2310900120Context> options)
        : base(options)
    {
    }

    public virtual DbSet<PvvEmployee> PvvEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-O5C67JAQ;Database=PhamVanVu_2310900120;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PvvEmployee>(entity =>
        {
            entity.HasKey(e => e.PvvEmpId).HasName("PK__PvvEmplo__41CC32013F0FBC1E");

            entity.ToTable("PvvEmployee");

            entity.Property(e => e.PvvEmpId)
                .ValueGeneratedNever()
                .HasColumnName("pvvEmpId");
            entity.Property(e => e.PvvEmpLevel)
                .HasMaxLength(50)
                .HasColumnName("pvvEmpLevel");
            entity.Property(e => e.PvvEmpName)
                .HasMaxLength(100)
                .HasColumnName("pvvEmpName");
            entity.Property(e => e.PvvEmpStartDate).HasColumnName("pvvEmpStartDate");
            entity.Property(e => e.PvvEmpStatus).HasColumnName("pvvEmpStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
