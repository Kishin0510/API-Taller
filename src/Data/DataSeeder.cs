using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Taller.src.Models;
using BCrypt.Net;
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

                if (!context.Genders.Any())
                {
                    context.Genders.AddRange(
                        new Gender { Type = "Masculino"},
                        new Gender { Type = "Femenino"},
                        new Gender { Type = "Prefiero no decirlo"},
                        new Gender { Type = "Otros"}    
                    );
                    context.SaveChanges();
                }

                if (!context.ProductTypes.Any())
                {
                    context.ProductTypes.AddRange(
                        new ProductType { Type = "Poleras"},
                        new ProductType { Type = "Gorros"},
                        new ProductType { Type = "Juguetería"},
                        new ProductType { Type = "Alimentación"},
                        new ProductType { Type = "Libros"}
                    );
                    context.SaveChanges();
                }

                if (!context.Users.Any()) 
                {   context.Users.AddRange(
                        new User { 
                        RUT = "20.416.699-4", 
                        Name = "Ignacio Mancilla", 
                        Email = "admin@idwm.cl",
                        Birthday = new DateTime(2000,10,25),
                        GenderId = 1,
                        Gender = context.Genders.First(g => g.Type == "Masculino"),
                        Password = BCrypt.Net.BCrypt.HashPassword("P4sssw0rd"),
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
                        .RuleFor(p => p.ImageUrl, f => f.Image.PicsumUrl())
                        .RuleFor(p => p.ImageId, f => f.Random.Guid().ToString())
                        .RuleFor(p => p.ProductTypeId, f => { var randomNumber = f.Random.Number(1,5); return randomNumber;})
                        .RuleFor(p => p.ProductType, (f,p) => context.ProductTypes.First(pt => pt.Id == p.ProductTypeId));
                    var products = productFaker.Generate(10);
                    for (int i = 0; i < products.Count; i++)
                    {
                        ProductType productType = context.ProductTypes.FirstOrDefault(p => p.Id == products[i].ProductTypeId);
                        Console.WriteLine(productType.Type);
                        if (productType != null)
                        {
                            products[i].ProductType = productType;
                        }
                    }
                    context.Products.AddRange(products);
                    context.SaveChanges();
                }

                context.SaveChanges();
            }
        }
    } 
}