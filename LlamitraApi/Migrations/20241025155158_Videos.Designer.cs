﻿// <auto-generated />
using System;
using LlamitraApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LlamitraApi.Migrations
{
    [DbContext(typeof(ProyectoIContext))]
    [Migration("20241025155158_Videos")]
    partial class Videos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LlamitraApi.Models.HistorialRefreshToken", b =>
                {
                    b.Property<int>("IdHistorialToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHistorialToken"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ExpiratedAt")
                        .HasColumnType("datetime");

                    b.Property<int?>("IdUser")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bit")
                        .HasComputedColumnSql("(case when [ExpiratedAt]<getdate() then CONVERT([bit],(0)) else CONVERT([bit],(1)) end)", false);

                    b.Property<string>("RefreshToken")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Token")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.HasKey("IdHistorialToken")
                        .HasName("PK__Historia__03DC48A5BDFD22AD");

                    b.HasIndex("IdUser");

                    b.ToTable("HistorialRefreshToken", (string)null);
                });

            modelBuilder.Entity("LlamitraApi.Models.Publication", b =>
                {
                    b.Property<int>("IdPublication")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idPublication");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPublication"));

                    b.Property<string>("Description")
                        .HasMaxLength(400)
                        .IsUnicode(false)
                        .HasColumnType("varchar(400)")
                        .HasColumnName("description");

                    b.Property<int>("IdType")
                        .HasColumnType("int")
                        .HasColumnName("idType");

                    b.Property<int>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("idUser");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("price");

                    b.Property<string>("Professor")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("professor");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("title");

                    b.HasKey("IdPublication")
                        .HasName("PK_idPublication");

                    b.HasIndex("IdType");

                    b.HasIndex("IdUser");

                    b.ToTable("Publication", (string)null);
                });

            modelBuilder.Entity("LlamitraApi.Models.PublicationRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdPublication")
                        .HasColumnType("int");

                    b.Property<int?>("IdPublicationNavigationIdPublication")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPublication");

                    b.HasIndex("IdPublicationNavigationIdPublication");

                    b.ToTable("PublicationRatings");
                });

            modelBuilder.Entity("LlamitraApi.Models.PublicationType", b =>
                {
                    b.Property<int>("IdType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idPublicationType");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdType"));

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("IdType")
                        .HasName("PK_idPublicationType");

                    b.ToTable("PublicationTypes");
                });

            modelBuilder.Entity("LlamitraApi.Models.Role", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idRol");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"));

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("IdRol")
                        .HasName("PK_idRol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("LlamitraApi.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idUser");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"));

                    b.Property<int>("IdRol")
                        .HasColumnType("int")
                        .HasColumnName("idRol");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("isActive");

                    b.Property<string>("Lastname")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("lastname");

                    b.Property<string>("Mail")
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("mail");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("password");

                    b.HasKey("IdUser")
                        .HasName("PK_idUser");

                    b.HasIndex("IdRol");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LlamitraApi.Models.Video", b =>
                {
                    b.Property<int>("IdVideo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdVideo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVideo"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<byte[]>("FileContent")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PublicationId")
                        .HasColumnType("int")
                        .HasColumnName("PublicationId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdVideo");

                    b.HasIndex("PublicationId");

                    b.ToTable("Video", (string)null);
                });

            modelBuilder.Entity("LlamitraApi.Models.HistorialRefreshToken", b =>
                {
                    b.HasOne("LlamitraApi.Models.User", "IdUserNavigation")
                        .WithMany("HistorialRefreshTokens")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK__Historial__IdUsu__24927208");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("LlamitraApi.Models.Publication", b =>
                {
                    b.HasOne("LlamitraApi.Models.PublicationType", "IdTypeNavigation")
                        .WithMany("Publications")
                        .HasForeignKey("IdType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Publications_IdType");

                    b.HasOne("LlamitraApi.Models.User", "IdUserNavigation")
                        .WithMany("Publications")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Publications__idRol");

                    b.Navigation("IdTypeNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("LlamitraApi.Models.PublicationRating", b =>
                {
                    b.HasOne("LlamitraApi.Models.Publication", null)
                        .WithMany()
                        .HasForeignKey("IdPublication")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LlamitraApi.Models.Publication", "IdPublicationNavigation")
                        .WithMany("PublicationRatings")
                        .HasForeignKey("IdPublicationNavigationIdPublication");

                    b.Navigation("IdPublicationNavigation");
                });

            modelBuilder.Entity("LlamitraApi.Models.User", b =>
                {
                    b.HasOne("LlamitraApi.Models.Role", "IdRolNavigation")
                        .WithMany("Users")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Users__idRol__3B75D760");

                    b.Navigation("IdRolNavigation");
                });

            modelBuilder.Entity("LlamitraApi.Models.Video", b =>
                {
                    b.HasOne("LlamitraApi.Models.Publication", "Publication")
                        .WithMany("Videos")
                        .HasForeignKey("PublicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publication");
                });

            modelBuilder.Entity("LlamitraApi.Models.Publication", b =>
                {
                    b.Navigation("PublicationRatings");

                    b.Navigation("Videos");
                });

            modelBuilder.Entity("LlamitraApi.Models.PublicationType", b =>
                {
                    b.Navigation("Publications");
                });

            modelBuilder.Entity("LlamitraApi.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("LlamitraApi.Models.User", b =>
                {
                    b.Navigation("HistorialRefreshTokens");

                    b.Navigation("Publications");
                });
#pragma warning restore 612, 618
        }
    }
}
