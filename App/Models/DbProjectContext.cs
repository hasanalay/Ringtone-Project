using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace App.Models;

public partial class DbProjectContext : DbContext
{
    public DbProjectContext()
    {
    }

    public DbProjectContext(DbContextOptions<DbProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CardPayment> CardPayments { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Ringtone> Ringtones { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CardPayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__card_pay__3213E83F083A84A2");

            entity.ToTable("card_payments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("amount");
            entity.Property(e => e.RingtoneId).HasColumnName("ringtone_id");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("transaction_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Ringtone).WithMany(p => p.CardPayments)
                .HasForeignKey(d => d.RingtoneId)
                .HasConstraintName("FK_card_payments_ringtones");

            entity.HasOne(d => d.User).WithMany(p => p.CardPayments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__card_paym__user___3A81B327");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_category_1");

            entity.ToTable("category");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("categoryName");
        });

        modelBuilder.Entity<Ringtone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ringtone__3213E83F3D82DFBB");

            entity.ToTable("ringtones");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Artist)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("artist");
            entity.Property(e => e.Audiourl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("audiourl");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.Details)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("details");
            entity.Property(e => e.Imageurl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imageurl");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");

            entity.HasOne(d => d.Category).WithMany(p => p.Ringtones)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_ringtones_category");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F39CC9B69");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
