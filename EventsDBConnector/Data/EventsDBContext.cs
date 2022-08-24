﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EventsDBConnector.Models;

namespace EventsDBConnector.Data
{
    public partial class EventsDBContext : DbContext
    {
        public EventsDBContext(DbContextOptions<EventsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clubs> Clubs { get; set; }
        public virtual DbSet<Leagues> Leagues { get; set; }
        public virtual DbSet<Sports> Sports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clubs>(entity =>
            {
                entity.ToTable("Clubs", "structure");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CurrentLeague).HasColumnName("currentLeague");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("name");

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("shortName");

                entity.HasOne(d => d.CurrentLeagueNavigation)
                    .WithMany(p => p.Clubs)
                    .HasForeignKey(d => d.CurrentLeague)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clubs_Leagues");
            });

            modelBuilder.Entity<Leagues>(entity =>
            {
                entity.ToTable("Leagues", "structure");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("name");

                entity.Property(e => e.PromotesTo).HasColumnName("promotesTo");

                entity.Property(e => e.SportId).HasColumnName("sportID");

                entity.HasOne(d => d.PromotesToNavigation)
                    .WithMany(p => p.InversePromotesToNavigation)
                    .HasForeignKey(d => d.PromotesTo)
                    .HasConstraintName("FK_Leagues_Leagues");

                entity.HasOne(d => d.Sport)
                    .WithMany(p => p.Leagues)
                    .HasForeignKey(d => d.SportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Leagues_Sports");
            });

            modelBuilder.Entity<Sports>(entity =>
            {
                entity.ToTable("Sports", "structure");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}