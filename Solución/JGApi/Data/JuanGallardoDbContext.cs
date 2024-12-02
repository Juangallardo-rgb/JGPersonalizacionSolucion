using System;
using System.Collections.Generic;
using JGApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JGApi.Data;

public partial class JuanGallardoDbContext : DbContext
{
    public JuanGallardoDbContext()
    {
    }

    public JuanGallardoDbContext(DbContextOptions<JuanGallardoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Jgadorno> Jgadornos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JuanGallardoDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Jgadorno>(entity =>
        {
            entity.HasKey(e => e.JgadornosId);

            entity.ToTable("JGadornos");

            entity.Property(e => e.JgadornosId).HasColumnName("JGadornosId");
            entity.Property(e => e.Jgname).HasColumnName("JGName");
            entity.Property(e => e.Jgnavideno).HasColumnName("JGnavideno");
            entity.Property(e => e.Jgprice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("JGprice");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
