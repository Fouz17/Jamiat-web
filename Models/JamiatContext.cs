﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Jamiat_web.Models
{
    public partial class JamiatContext : DbContext
    {
        public JamiatContext()
        {
        }

        public JamiatContext(DbContextOptions<JamiatContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Associations> Associations { get; set; }
        public virtual DbSet<Halqa> Halqa { get; set; }
        public virtual DbSet<Ilaqa> Ilaqa { get; set; }
        public virtual DbSet<MenuMappingMaster> MenuMappingMaster { get; set; }
        public virtual DbSet<MenuMappings> MenuMappings { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<Responsibilities> Responsibilities { get; set; }
        public virtual DbSet<Shaheens> Shaheens { get; set; }
        public virtual DbSet<UserRespMapping> UserRespMapping { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Zones> Zones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=161.97.142.142;Initial Catalog=fouz;Persist Security Info=True;User ID=fouz;Password=fouz;Encrypt=false;TrustServerCertificate=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Associations>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Halqa>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Ilaqa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IlaqaNavigation)
                    .WithMany(p => p.Halqa)
                    .HasForeignKey(d => d.Ilaqa)
                    .HasConstraintName("FK_Halqa_Ilaqa");
            });

            modelBuilder.Entity<Ilaqa>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ZoneNavigation)
                    .WithMany(p => p.Ilaqa)
                    .HasForeignKey(d => d.Zone)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ilaqa_Zones");
            });

            modelBuilder.Entity<MenuMappingMaster>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RespLevel)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Resp)
                    .WithMany(p => p.MenuMappingMaster)
                    .HasForeignKey(d => d.RespId)
                    .HasConstraintName("FK_MenuMappingMaster_Responsibilities");
            });

            modelBuilder.Entity<MenuMappings>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.MasterId).HasColumnName("MasterID");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.HasOne(d => d.Master)
                    .WithMany(p => p.MenuMappings)
                    .HasForeignKey(d => d.MasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuMappings_MenuMappingMaster");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuMappings)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuMappings_Menus");
            });

            modelBuilder.Entity<Menus>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Menu)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<Responsibilities>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Shaheens>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRespMapping>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RespLevel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Resp)
                    .WithMany(p => p.UserRespMapping)
                    .HasForeignKey(d => d.RespId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRespMapping_Responsibilities");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRespMapping)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRespMapping_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.HasOne(d => d.AssociationNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Association)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Associations");
            });

            modelBuilder.Entity<Zones>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingGeneratedProcedures(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}