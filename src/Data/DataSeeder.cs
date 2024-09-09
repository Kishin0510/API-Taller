using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.Models;
using Bogus;

namespace Api_Taller.src.Data
{
    public class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDBContext>();

                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(
                        new Role { Name = "Admin" },
                        new Role { Name = "User" }
                    );
                    context.SaveChanges();
                }

                if (!context.Users.Any()) 
                {   context.Users.AddRange(
                        new User { 
                        RUT = "20.416.699-4", 
                        Name = "Ignacio Mancilla", 
                        Email = "admin@idwm.cl",
                        birthday = "25/10/2000",
                        Gender = "Masculino",
                        Password = "P4sssw0rd",
                        IsEnabled = true,
                        RoleId = context.Roles.First(r => r.Name == "Admin").Id,
                        Role = context.Roles.First(r => r.Name == "Admin")
                        }
                    );
                    context.SaveChanges();
                }

                if(!context.Products.Any()) 
                {
                    var productFaker = new Faker<Product>()
                        .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                        .RuleFor(p => p.Price, f => f.Random.Number(1000, 100000))
                        .RuleFor(p => p.Stock, f => f.Random.Number(0, 1000))
                        .RuleFor(p => p.ImageUrl, f => f.Image.PicsumUrl());
                    var products = productFaker.Generate(10);
                    context.Products.AddRange(products);
                    context.SaveChanges();
                }

                context.SaveChanges();
            }
        }
    } 
}