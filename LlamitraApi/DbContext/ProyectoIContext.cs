using System;
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

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<InLive> InLives { get; set; }

    public virtual DbSet<Presential> Presentials { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Video> Videos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //       => optionsBuilder.UseSqlServer("Data Source=DESKTOP-TH76ASN; Initial Catalog=ProyectoI; Trusted_Connection=True;MultipleActiveResultSets=true;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PK_idCategory");

            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<InLive>(entity =>
        {
            entity.HasKey(e => e.IdLive).HasName("PK_idLive");

            entity.ToTable("InLive");

            entity.Property(e => e.IdLive).HasColumnName("idLive");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("description");
            //entity.Property(e => e.IdCategory).HasColumnName("idCategory");
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
            entity.Property(e => e.Url)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("url");

            /*entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.InLives)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK__InLive__idCatego__4222D4EF");*/
        });

        modelBuilder.Entity<Presential>(entity =>
        {
            entity.HasKey(e => e.IdPresential).HasName("PK_idPresential");

            entity.ToTable("Presential");

            entity.Property(e => e.IdPresential).HasColumnName("idPresential");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("description");
            //entity.Property(e => e.IdCategory).HasColumnName("idCategory");
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

            /*entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Presentials)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK__Presentia__idCat__47DBAE45");*/
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
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Users__idRol__3B75D760");
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.HasKey(e => e.IdVideo).HasName("PK_idVideo");

            entity.Property(e => e.IdVideo).HasColumnName("idVideo");
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("description");
            //entity.Property(e => e.IdCategory).HasColumnName("idCategory");
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
            entity.Property(e => e.Url)
                .HasMaxLength(450)
                .IsUnicode(false)
                .HasColumnName("url");

            /*entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Videos)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK__Videos__idCatego__44FF419A");*/
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
