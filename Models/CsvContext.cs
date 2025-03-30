using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace onpmysql.Models;

public partial class CsvContext : DbContext
{
    public CsvContext()
    {
    }

    public CsvContext(DbContextOptions<CsvContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Corona> Coronas { get; set; }

    public virtual DbSet<CoronaCopy> CoronaCopies { get; set; }

    public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; }

    public virtual DbSet<InvoicesChild> InvoicesChildren { get; set; }

    public virtual DbSet<Summary> Summaries { get; set; }

    public virtual DbSet<Twitter> Twitters { get; set; }

    public virtual DbSet<TwitterCopy> TwitterCopies { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder);
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseMySql("server=localhost;database=csv;user=pashi;password=4496", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.41-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Corona>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PRIMARY");

            entity.ToTable("corona");

            entity.Property(e => e.CountryId)
                .ValueGeneratedNever()
                .HasColumnName("country_id");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(40);
            entity.Property(e => e.State).HasMaxLength(30);
            entity.Property(e => e.StateCleaned)
                .HasMaxLength(30)
                .HasColumnName("State_cleaned");
        });

        modelBuilder.Entity<CoronaCopy>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("corona_copy");

            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(40);
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.State).HasMaxLength(30);
            entity.Property(e => e.StateCleaned)
                .HasMaxLength(30)
                .HasColumnName("State_cleaned");
        });

        modelBuilder.Entity<EfmigrationsHistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__EFMigrationsHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<InvoicesChild>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("InvoicesChild");

            entity.HasIndex(e => e.InvoiceId, "FK_InvoicesChild_InvoicesChild_InvoiceId");

            entity.Property(e => e.Id)
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.ContactName).HasMaxLength(32);
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.DueDate).HasMaxLength(16);
            entity.Property(e => e.InvoiceDate).HasMaxLength(16);
            entity.Property(e => e.InvoiceId)
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.InvoiceNumber).HasMaxLength(32);

            entity.HasOne(d => d.Invoice).WithMany(p => p.InverseInvoice).HasForeignKey(d => d.InvoiceId);
        });

        modelBuilder.Entity<Summary>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("summary");

            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.DestCountryName)
                .HasColumnType("mediumtext")
                .HasColumnName("DEST_COUNTRY_NAME");
            entity.Property(e => e.OriginCountryName)
                .HasColumnType("mediumtext")
                .HasColumnName("ORIGIN_COUNTRY_NAME");
        });

        modelBuilder.Entity<Twitter>(entity =>
        {
            entity.HasKey(e => e.C0).HasName("PRIMARY");

            entity.ToTable("twitter");

            entity.Property(e => e.C0)
                .ValueGeneratedNever()
                .HasColumnName("_c0");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.Entities)
                .HasColumnType("mediumtext")
                .HasColumnName("entities");
            entity.Property(e => e.Geo)
                .HasColumnType("tinytext")
                .HasColumnName("geo");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .HasColumnName("location");
            entity.Property(e => e.Sentiment)
                .HasMaxLength(100)
                .HasColumnName("sentiment");
            entity.Property(e => e.Text)
                .HasColumnType("mediumtext")
                .HasColumnName("text");
            entity.Property(e => e.User)
                .HasMaxLength(70)
                .HasColumnName("user");
        });

        modelBuilder.Entity<TwitterCopy>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("twitter_copy");

            entity.Property(e => e.C0).HasColumnName("_c0");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.Entities)
                .HasColumnType("mediumtext")
                .HasColumnName("entities");
            entity.Property(e => e.Geo)
                .HasColumnType("tinytext")
                .HasColumnName("geo");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .HasColumnName("location");
            entity.Property(e => e.Sentiment)
                .HasMaxLength(100)
                .HasColumnName("sentiment");
            entity.Property(e => e.Text)
                .HasColumnType("mediumtext")
                .HasColumnName("text");
            entity.Property(e => e.User)
                .HasMaxLength(70)
                .HasColumnName("user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
