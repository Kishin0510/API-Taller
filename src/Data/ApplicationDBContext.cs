using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Taller.src.Data
{
    public class ApplicationDBContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<Gender> Genders { get; set; } = null!;
        public DbSet<ProductType> ProductTypes { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Purchase> Purchases { get; set; } = null!;
        public DbSet<PurchaseProduct> PurchaseProducts { get; set; } = null!;
        public DbSet<Cart> Cart { get; set; } = null!;
        public DbSet<CartItem> CartItem { get; set; } = null!;
    }
}