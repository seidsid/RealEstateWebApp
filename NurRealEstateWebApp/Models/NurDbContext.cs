using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NurRealEstateWebApp.Entities;
using Pomelo.EntityFrameworkCore.MySql;
using System;
using System.Collections.Generic;

namespace NurRealEstateWebApp.Models
{
    public partial class NurDbContext : IdentityDbContext<AppUser>
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
            base.OnModelCreating(modelBuilder);

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

                entity.Property(e => e.AddressId)
                    .HasMaxLength(36)
                    .HasColumnName("address_id");
                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .HasColumnName("city");
                entity.Property(e => e.HouseNo)
                    .HasMaxLength(50)
                    .HasColumnName("house_no");
                entity.Property(e => e.SubCity)
                    .HasMaxLength(100)
                    .HasColumnName("sub_city");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.AdminId).HasName("PRIMARY");

                entity.ToTable("admin");

                entity.Property(e => e.AdminId)
                    .HasMaxLength(36)
                    .HasColumnName("admin_id");

                entity.HasOne(a => a.Account)
                    .WithOne()
                    .HasForeignKey<Admin>("account_id")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("admin_ibfk_3");

                entity.HasOne(d => d.Contact)
                    .WithOne()
                    .HasForeignKey<Admin>("contact_id")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("admin_ibfk_1");

                entity.HasMany(d => d.Agents)
                    .WithOne(a => a.Admin)
                    .HasForeignKey("admin_id") // admin table doesn't contain agent_id / instead agent table contain admin_id
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Agent>(entity =>
            {
                entity.HasKey(e => e.AgentId).HasName("PRIMARY");

                entity.ToTable("agent");

                entity.Property(e => e.AgentId)
                    .HasMaxLength(36)
                    .HasColumnName("agent_id");

                entity.Property(e => e.ExperienceSince)
                    .HasColumnType("datetime")
                    .HasColumnName("experience_since");

                entity.Property(e => e.Languages)
                    .HasMaxLength(100)
                    .HasColumnName("languages");

                entity.Property(e => e.Nationality)
                    .HasMaxLength(50)
                    .HasColumnName("nationality");

                entity.HasOne(d => d.Account)
                    .WithOne()
                    .HasForeignKey<Agent>("account_id")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("agent_ibfk_3");

                entity.HasOne(d => d.Admin)
                    .WithMany(a => a.Agents)
                    .HasForeignKey("admin_id")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("agent_ibfk_4");

                entity.HasOne(d => d.Contact)
                    .WithOne()
                    .HasForeignKey<Agent>("contact_id")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("agent_ibfk_1");

                entity.HasMany(d => d.Properties)
                    .WithOne(a => a.Agent)
                    .HasForeignKey("agent_id") // agent table doesn't contain property_id / instead property table contain agent id
                    .OnDelete(DeleteBehavior.ClientSetNull);
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

                entity.Property(e => e.PropertyId)
                    .HasMaxLength(36)
                    .HasColumnName("property_id");
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

                entity.HasOne(d => d.Agent)
                    .WithMany(p => p.Properties)
                    .HasForeignKey("agent_id") 
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("property_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Properties)
                    .HasForeignKey("user_id")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("property_ibfk_1");

                entity.HasOne(d => d.Address)
                     .WithOne()
                     .HasForeignKey<Property>("address_id")
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("property_ibfk_3");

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PRIMARY");

                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .HasMaxLength(36)
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Account)
                    .WithOne()
                    .HasForeignKey<User>("account_id")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_ibfk_2");

                entity.HasOne(d => d.Contact)
                    .WithOne()
                    .HasForeignKey<User>("contact_id")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_ibfk_3");

                entity.HasMany(d => d.Properties)
                    .WithOne(u => u.User)
                    .HasForeignKey("user_id") //.HasForeignKey("property_id") not good cause user table doesn't have a property_id column
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
