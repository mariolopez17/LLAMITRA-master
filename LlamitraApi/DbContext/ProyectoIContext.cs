﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LlamitraApi.Models;

public partial class ProyectoIContext : DbContext
{
    public ProyectoIContext()
    {

    }

    public ProyectoIContext(DbContextOptions<ProyectoIContext> options)
        : base(options)
    {
    }
    public virtual DbSet<PublicationType> PublicationTypes { get; set; }
    public virtual DbSet<Publication> Publications { get; set; }
    public virtual DbSet<HistorialRefreshToken> HistorialRefreshTokens { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<PublicationRating> PublicationRatings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PublicationRating>()
            .HasKey(pr => pr.Id);

        modelBuilder.Entity<PublicationRating>()
            
            .HasOne<Publication>()
            .WithMany()
            .HasForeignKey(pr => pr.IdPublication)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<HistorialRefreshToken>(entity =>
        {
            entity.HasKey(e => e.IdHistorialToken).HasName("PK__Historia__03DC48A5BDFD22AD");

            entity.ToTable("HistorialRefreshToken");

            entity.Property(e => e.IsActive).HasComputedColumnSql("(case when [ExpiratedAt]<getdate() then CONVERT([bit],(0)) else CONVERT([bit],(1)) end)", false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.ExpiratedAt).HasColumnType("datetime");
            entity.Property(e => e.RefreshToken)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Token)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.HistorialRefreshTokens)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Historial__IdUsu__24927208");
        });
        modelBuilder.Entity<PublicationType>(entity =>
        {
            entity.HasKey(e => e.IdType).HasName("PK_idPublicationType");

            entity.Property(e => e.IdType).HasColumnName("idPublicationType");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });
        modelBuilder.Entity<Publication>()
            .Property(p => p.FileName).HasColumnName("FileName");
        modelBuilder.Entity<Publication>()
            .Property(p => p.FileContent).HasColumnName("FileContent");

        modelBuilder.Entity<Publication>(entity =>
        {
            entity.HasKey(e => e.IdPublication).HasName("PK_idPublication");

            entity.ToTable("Publication");

            entity.Property(e => e.IdPublication).HasColumnName("idPublication");
            entity.Property(e => e.IdType).HasColumnName("idType");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(p => p.FileName).HasColumnName("FileName");
            entity.Property(p => p.FileContent).HasColumnName("FileContent");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Professor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("professor");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.Publications)
                .HasForeignKey(d => d.IdType)
                .HasConstraintName("FK_Publications_IdType");
            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Publications)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Publications__idRol");
            
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK_idRol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK_idUser");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Mail)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("mail");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("password");


            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Users__idRol__3B75D760");
        });
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
