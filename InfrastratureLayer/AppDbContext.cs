using DomainLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastratureLayer
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null;
        public DbSet<Role> Roles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {
             
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(
                b =>
                {
                    b.HasKey(u => u.Id);
                    b.Property(u=>u.UserName).IsRequired();
                    b.Property(u=>u.PasswordHash).IsRequired();
                });

            modelBuilder.Entity<Role>(b =>
            {
                b.HasKey(u => u.Id);
                b.Property(u => u.RoleType).IsRequired();
            });

            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity(j => j.ToTable("UserRoles"));

        }

    }
}
