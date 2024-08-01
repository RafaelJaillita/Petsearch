using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PetSearch.Models
{
    public partial class dbDorianContext : DbContext
    {
        public dbDorianContext()
        {
        }

        public dbDorianContext(DbContextOptions<dbDorianContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FoundPet> FoundPets { get; set; } = null!;
        public virtual DbSet<SearchPet> SearchPets { get; set; } = null!;
        public virtual DbSet<Sheltter> Sheltters { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Modern_Spanish_CI_AS");

            modelBuilder.Entity<FoundPet>(entity =>
            {
                entity.ToTable("FoundPet");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cellphone).HasColumnName("cellphone");

                entity.Property(e => e.ImagePet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("imagePet");

                entity.Property(e => e.LastSeenAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("lastSeenAddress");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("lastUpdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registerDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UserId).HasColumnName("userID");
            });

            modelBuilder.Entity<SearchPet>(entity =>
            {
                entity.ToTable("SearchPet");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AnimalName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("animalName");

                entity.Property(e => e.Breed)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("breed");

                entity.Property(e => e.Cellphone).HasColumnName("cellphone");

                entity.Property(e => e.Color)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.ImagePet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("imagePet");

                entity.Property(e => e.LastSeenAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("lastSeenAddress");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("lastUpdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Message)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("message");

                entity.Property(e => e.RegisteraDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registeraDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UserId).HasColumnName("userID");
            });

            modelBuilder.Entity<Sheltter>(entity =>
            {
                entity.ToTable("Sheltter");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Cellphone).HasColumnName("cellphone");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("lastUpdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NameSheltter)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nameSheltter");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registerDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("emailAddress");

                entity.Property(e => e.FullName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("fullName");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registerDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rol)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("rol")
                    .HasDefaultValueSql("('user')");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
