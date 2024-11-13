using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;


namespace LlamitraApi.Models;

public partial class ProyectoIContext : DbContext
{
    public ProyectoIContext() { }

    public ProyectoIContext(DbContextOptions<ProyectoIContext> options)
        : base(options) { }

    public virtual DbSet<PublicationType> PublicationTypes { get; set; }
    public virtual DbSet<Publication> Publications { get; set; }
    public virtual DbSet<HistorialRefreshToken> HistorialRefreshTokens { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<PublicationRating> PublicationRatings { get; set; }
    public virtual DbSet<Video> Videos { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

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

        modelBuilder.Entity<Publication>(entity =>
        {
            entity.HasKey(e => e.IdPublication).HasName("PK_idPublication");

            entity.ToTable("Publication");

            entity.Property(e => e.IdPublication).HasColumnName("idPublication");
            entity.Property(e => e.Description).HasMaxLength(400).IsUnicode(false).HasColumnName("description");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)").HasColumnName("price");
            entity.Property(e => e.Professor).HasMaxLength(20).IsUnicode(false).HasColumnName("professor");
            entity.Property(e => e.Title).HasMaxLength(50).IsUnicode(false).HasColumnName("title");
            entity.Property(e => e.DescriptionProgram).IsUnicode(false).HasColumnName("descriptionProgram");
            entity.Property(e => e.Duration).IsUnicode(false).HasColumnName("duration");
            entity.Property(e => e.DurationWeek).IsUnicode(false).HasColumnName("durationWeek");
            entity.Property(e => e.Category).IsUnicode(false).HasColumnName("category");
            entity.Property(e => e.KnowledgeLevel).IsUnicode(false).HasColumnName("knowledgeLevel");
            entity.Property(e => e.Favorite).HasColumnName("favorite");
            entity.Property(e => e.Comprado).HasColumnName("comprado");

            
            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.Publications)
                .HasForeignKey(d => d.IdType)
                .HasConstraintName("FK_Publications_IdType");
            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Publications)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_Publications_IdUser");

            
            entity.HasMany(e => e.Videos)
                .WithOne(e => e.Publication)
                .HasForeignKey(e => e.PublicationId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.HasKey(v => v.IdVideo);

            entity.ToTable("Video");

            entity.Property(v => v.IdVideo).HasColumnName("IdVideo");
            entity.Property(v => v.PublicationId).HasColumnName("PublicationId");
            entity.Property(v => v.Title).HasMaxLength(100).IsRequired();
            entity.Property(v => v.Description).HasMaxLength(500);

            
            var converter = new ValueConverter<List<string>, string>(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v) ?? new List<string>()
            );

            var comparer = new ValueComparer<List<string>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList()
            );

            entity.Property(v => v.FilePath)
                .HasConversion(converter)
                .HasColumnType("nvarchar(max)");

            
            entity.Property(v => v.FilePath)
                .Metadata.SetValueComparer(comparer);


            entity.HasOne(v => v.Publication)
                .WithMany(p => p.Videos)
                .HasForeignKey(v => v.PublicationId)
                .OnDelete(DeleteBehavior.Cascade);
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
