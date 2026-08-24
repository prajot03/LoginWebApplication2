using DomainLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace InfrastratureLayer
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null;
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; } = null;

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

            modelBuilder.Entity<Category>(
                b =>
                {
                    b.HasKey(u => u.Id);
                    b.Property(u => u.CategoryName).IsRequired();
                }
                );


            modelBuilder.Entity<Product>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.productName).IsRequired();
                b.Property(p => p.price).IsRequired();
                b.Property(p => p.quantity).IsRequired();
                b.HasOne(p => p.productCategory)
                    .WithMany()
                    .HasForeignKey(p => p.CategoryId);


            });


          
                

        }

    }
}
