using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using NurRealEstateWebApp.Entities;
using Pomelo.EntityFrameworkCore.MySql;
using System;
using System.Collections.Generic;

namespace NurRealEstateWebApp.Models
{
    public partial class NurDbContext : DbContext
    {

        public NurDbContext(DbContextOptions<NurDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Admin> Admins { get; set; }

        public virtual DbSet<Agent> Agents { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<Property> Properties { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

            => optionsBuilder.UseMySQL("server=localhost;database=nur_real_estate;user=root;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccountId).HasName("PRIMARY");

                entity.ToTable("account");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(36)
                    .HasColumnName("account_id");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .HasColumnName("first_name");
                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .HasColumnName("last_name");
                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .HasColumnName("password");
                entity.Property(e => e.Role)
                    .HasMaxLength(255)
                    .HasColumnName("role");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.AddressId).HasName("PRIMARY");

                entity.ToTable("address");

                entity.HasIndex(e => e.PropertyId, "property_id");

                entity.Property(e => e.AddressId)
                    .HasMaxLength(36)
                    .HasColumnName("address_id");
                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .HasColumnName("city");
                entity.Property(e => e.HouseNo)
                    .HasMaxLength(50)
                    .HasColumnName("house_no");
                entity.Property(e => e.PropertyId)
                    .HasMaxLength(36)
                    .HasColumnName("property_id");
                entity.Property(e => e.SubCity)
                    .HasMaxLength(100)
                    .HasColumnName("sub_city");

                entity.HasOne(d => d.Property)
                      .WithOne(p => p.Address)
                      .HasForeignKey<Address>(d => d.PropertyId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("address_ibfk_1");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.AdminId).HasName("PRIMARY");

                entity.ToTable("admin");

                entity.HasIndex(e => e.AccountId, "account_id");

                entity.HasIndex(e => new { e.ContactId, e.AccountId }, "contact_id");

                entity.Property(e => e.AdminId)
                    .HasMaxLength(36)
                    .HasColumnName("admin_id");
                entity.Property(e => e.AccountId)
                    .HasMaxLength(36)
                    .HasColumnName("account_id");
                entity.Property(e => e.ContactId)
                    .HasMaxLength(36)
                    .HasColumnName("contact_id");

                entity.HasOne(d => d.Account).WithMany(p => p.Admins)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("admin_ibfk_3");

                entity.HasOne(d => d.Contact).WithMany(p => p.Admins)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("admin_ibfk_1");
            });

            modelBuilder.Entity<Agent>(entity =>
            {
                entity.HasKey(e => e.AgentId).HasName("PRIMARY");

                entity.ToTable("agent");

                entity.HasIndex(e => e.AccountId, "account_id");

                entity.HasIndex(e => e.AdminId, "agent_ibfk_3_idx");

                entity.HasIndex(e => new { e.ContactId, e.AccountId }, "contact_id");

                entity.Property(e => e.AgentId)
                    .HasMaxLength(36)
                    .HasColumnName("agent_id");
                entity.Property(e => e.AccountId)
                    .HasMaxLength(36)
                    .HasColumnName("account_id");
                entity.Property(e => e.AdminId)
                    .HasMaxLength(36)
                    .HasColumnName("admin_id");
                entity.Property(e => e.ContactId)
                    .HasMaxLength(36)
                    .HasColumnName("contact_id");
                entity.Property(e => e.ExperienceSince)
                    .HasColumnType("datetime")
                    .HasColumnName("experience_since");
                entity.Property(e => e.Languages)
                    .HasMaxLength(100)
                    .HasColumnName("languages");
                entity.Property(e => e.Nationality)
                    .HasMaxLength(50)
                    .HasColumnName("nationality");

                entity.HasOne(d => d.Account).WithMany(p => p.Agents)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("agent_ibfk_3");

                entity.HasOne(d => d.Admin).WithMany(p => p.Agents)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("agent_ibfk_4");

                entity.HasOne(d => d.Contact).WithMany(p => p.Agents)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("agent_ibfk_1");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.ContactId).HasName("PRIMARY");

                entity.ToTable("contact");

                entity.Property(e => e.ContactId)
                    .HasMaxLength(36)
                    .HasColumnName("contact_id");
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");
                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(15)
                    .HasColumnName("phone_no");
                entity.Property(e => e.WhatsappNo)
                    .HasMaxLength(15)
                    .HasColumnName("whatsapp_no");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasKey(e => e.PropertyId).HasName("PRIMARY");

                entity.ToTable("property");

                entity.HasIndex(e => e.AgentId, "agent_id");

                entity.HasIndex(e => new { e.UserId, e.AgentId }, "user_id");

                entity.Property(e => e.PropertyId)
                    .HasMaxLength(36)
                    .HasColumnName("property_id");
                entity.Property(e => e.AgentId)
                    .HasMaxLength(36)
                    .HasColumnName("agent_id");
                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");
                entity.Property(e => e.HasMaidsRoom).HasColumnName("has_maidsRoom");
                entity.Property(e => e.ListedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("listed_date");
                entity.Property(e => e.NoBathrooms)
                    .HasColumnType("int(11)")
                    .HasColumnName("no_bathrooms");
                entity.Property(e => e.NoBedrooms)
                    .HasColumnType("int(11)")
                    .HasColumnName("no_bedrooms");
                entity.Property(e => e.NoParking)
                    .HasColumnType("int(11)")
                    .HasColumnName("no_parking");
                entity.Property(e => e.Price).HasColumnName("price");
                entity.Property(e => e.PropertySize)
                    .HasColumnType("int(11)")
                    .HasColumnName("property_size");
                entity.Property(e => e.PropertyType)
                    .HasMaxLength(255)
                    .HasColumnName("property_type");
                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");
                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");
                entity.Property(e => e.UserId)
                    .HasMaxLength(36)
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Agent).WithMany(p => p.Properties)
                    .HasForeignKey(d => d.AgentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("property_ibfk_1");

                entity.HasOne(d => d.User).WithMany(p => p.Properties)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("property_ibfk_2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PRIMARY");

                entity.ToTable("user");

                entity.HasIndex(e => e.AccountId, "account_id");

                entity.HasIndex(e => e.ContactId, "contact_id");

                entity.Property(e => e.UserId)
                    .HasMaxLength(36)
                    .HasColumnName("user_id");
                entity.Property(e => e.AccountId)
                    .HasMaxLength(36)
                    .HasColumnName("account_id");
                entity.Property(e => e.ContactId)
                    .HasMaxLength(36)
                    .HasColumnName("contact_id");

                entity.HasOne(d => d.Account).WithMany(p => p.Users)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_ibfk_2");

                entity.HasOne(d => d.Contact).WithMany(p => p.Users)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_ibfk_3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
