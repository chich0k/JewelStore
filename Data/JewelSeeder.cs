using Microsoft.EntityFrameworkCore;
using JewelStore.Models;

namespace JewelStore.Data;

// Начальные данные JewelStore — ювелирный магазин
public static class JewelSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Кольца", Description = "Обручальные и помолвочные кольца" },
            new Category { Id = 2, Name = "Серьги", Description = "Серьги-гвоздики, висячие, кольца" },
            new Category { Id = 3, Name = "Браслеты", Description = "Золотые и серебряные браслеты" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Кольцо с бриллиантом 0.5 ct", Description = "Белое золото 585 пробы", Price = 149990m, Stock = 3, CategoryId = 1, ImageUrl = "https://placehold.co/400x400/1a1a1a/c9a227?text=Diamond+Ring", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Product { Id = 2, Name = "Обручальное кольцо классика", Description = "Золото 585 пробы", Price = 24990m, Stock = 12, CategoryId = 1, ImageUrl = "https://placehold.co/400x400/c9a227/1a1a1a?text=Wedding+Ring", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Product { Id = 3, Name = "Серьги с сапфиром", Description = "Золото 750 пробы, синий сапфир", Price = 89990m, Stock = 5, CategoryId = 2, ImageUrl = "https://placehold.co/400x400/1a1a1a/c9a227?text=Sapphire", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Product { Id = 4, Name = "Серьги-гвоздики жемчуг", Description = "Серебро 925 + натуральный жемчуг", Price = 6990m, Stock = 18, CategoryId = 2, ImageUrl = "https://placehold.co/400x400/c9a227/1a1a1a?text=Pearl", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Product { Id = 5, Name = "Браслет панцирное плетение", Description = "Золото 585 пробы, 19 см", Price = 79990m, Stock = 6, CategoryId = 3, ImageUrl = "https://placehold.co/400x400/1a1a1a/c9a227?text=Gold+Bracelet", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Product { Id = 6, Name = "Серебряный браслет с фианитом", Description = "Серебро 925 пробы", Price = 8990m, Stock = 14, CategoryId = 3, ImageUrl = "https://placehold.co/400x400/c9a227/1a1a1a?text=Silver", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
        );

        modelBuilder.Entity<ProductDetails>().HasData(
            new ProductDetails { Id = 1, ProductId = 1, Manufacturer = "Sokolov", CountryOfOrigin = "Россия", Weight = 0.003, Dimensions = "Размер 17", WarrantyMonths = 12 },
            new ProductDetails { Id = 2, ProductId = 3, Manufacturer = "Diamant", CountryOfOrigin = "Россия", Weight = 0.005, Dimensions = "1.5x1 см", WarrantyMonths = 12 },
            new ProductDetails { Id = 3, ProductId = 5, Manufacturer = "585 Gold", CountryOfOrigin = "Россия", Weight = 0.012, Dimensions = "Длина 19 см", WarrantyMonths = 24 }
        );

        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, FullName = "Виктория Бриллиант", Email = "victoria@jewelstore.local", Phone = "+7-966-000-00-07", Address = "Москва, Кузнецкий Мост, 1", RegisteredAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
        );
    }
}
