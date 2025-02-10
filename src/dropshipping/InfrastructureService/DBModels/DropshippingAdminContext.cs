﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureService.DBModels;

public partial class DropshippingAdminContext : DbContext
{
    public DropshippingAdminContext(DbContextOptions<DropshippingAdminContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentsStatus> PaymentsStatuses { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WhatsAppMessage> WhatsAppMessages { get; set; }

    public virtual DbSet<WhatsAppMessagesStatus> WhatsAppMessagesStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3214EC07DF422922");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Content).IsRequired();
            entity.Property(e => e.SentAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__UserI__5165187F");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payments__3214EC07C801055D");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("FK__Payments__Status__412EB0B6");

            entity.HasOne(d => d.User).WithMany(p => p.Payments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payments__UserId__403A8C7D");
        });

        modelBuilder.Entity<PaymentsStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payments__3214EC0706B7AD5A");

            entity.ToTable("PaymentsStatus");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transact__3214EC07577C513F");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Gateway)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.TransactionId)
                .IsRequired()
                .HasMaxLength(255);

            entity.HasOne(d => d.Payment).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__Payme__44FF419A");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0754D76BA4");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105348D0D612F").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.TwoFactorEnabled).HasDefaultValue(false);
        });

        modelBuilder.Entity<WhatsAppMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WhatsApp__3214EC07684958E5");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.MessageContent).IsRequired();
            entity.Property(e => e.SentAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.WhatsAppMessages)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("FK__WhatsAppM__Statu__4E88ABD4");

            entity.HasOne(d => d.User).WithMany(p => p.WhatsAppMessages)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WhatsAppM__UserI__4CA06362");
        });

        modelBuilder.Entity<WhatsAppMessagesStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WhatsApp__3214EC07293D2C54");

            entity.ToTable("WhatsAppMessagesStatus");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.SentAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}