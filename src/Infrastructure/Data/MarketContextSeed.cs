﻿using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class MarketContextSeed
    {
        public static async Task SeedAsync(MarketContext db)
        {
            if (await db.Categories.AnyAsync() || await db.Brands.AnyAsync() || await db.Styles.AnyAsync() || await db.Products.AnyAsync()) return;

            var man = new Category() { Name = "Man" };
            var woman = new Category() { Name = "Woman" };
            db.AddRange(man, woman);
            await db.SaveChangesAsync();

            var fossil = new Brand() { Name = "Fossil" };
            var michaelKors = new Brand() { Name = "Michael Kors" };
            var wesse = new Brand() { Name = "Wesse" };
            db.AddRange(fossil, michaelKors, wesse);
            await db.SaveChangesAsync();

            var classic = new Style() { Name = "Classic" };
            var sport = new Style() { Name = "Sport" };
            var smart = new Style() { Name = "Smart" };
            db.AddRange(classic, sport, smart);
            await db.SaveChangesAsync();

            Product[] products = {
                new Product() { Name = "Fossil FES4274", Price = 84.99m, PictureUri = "1.jpg", Brand = fossil, Category = woman, Style = classic, DiscountRate = 20, SalesQuantity = 105, StockQuantity = 1005,
                    Description = "watchband : steel / technology : quartz / diameter : 36mm / shape: round / glass-type : mineral / waterproof : 3 ATM" },
                new Product() { Name = "Fossil FBQ3628", Price = 97.50m, PictureUri = "2.jpg", Brand = fossil, Category = woman, Style = sport, DiscountRate = 20, SalesQuantity = 106, StockQuantity = 1006,
                    Description = "watchband : steel / technology : quartz / diameter : 38mm / shape: round / glass-type : mineral / waterproof : 5 ATM" },
                new Product() { Name = "Fossil FTW6051", Price = 165.00m, PictureUri = "3.jpg", Brand = fossil, Category = woman, Style = smart, DiscountRate = 20, SalesQuantity = 107, StockQuantity = 1007,
                    Description = "watchband : steel / technology : touchscreen smartwatch technology / diameter : 41mm / shape: round / glass-type : mineral / waterproof : 5 ATM" },
                new Product() { Name = "Fossil FFS5666", Price = 64.99m, PictureUri = "4.jpg", Brand = fossil, Category = man, Style = classic, DiscountRate = 20, SalesQuantity = 108, StockQuantity = 1008,
                    Description = "watchband : steel / technology : quartz / diameter : 42mm / shape: round / glass-type : mineral / waterproof : 5 ATM" },
                new Product() { Name = "Fossil FJR1354", Price = 120.50m, PictureUri = "5.jpg", Brand = fossil, Category = man, Style = sport, DiscountRate = 20, SalesQuantity = 109, StockQuantity = 1009,
                    Description = "watchband : steel / technology : quartz / diameter : 50mm / shape: round / glass-type : mineral / waterproof : 5 ATM" },
                new Product() { Name = "Fossil FTW4047", Price = 241.50m, PictureUri = "6.jpg", Brand = fossil, Category = man, Style = smart, DiscountRate = 20, SalesQuantity = 110, StockQuantity = 1010,
                    Description = "watchband : steel / technology : touchscreen smartwatch technology / diameter : 44mm / shape: round / glass-type : mineral / waterproof : 3 ATM" },
                new Product() { Name = "Michael Kors MK2748", Price = 115.00m, PictureUri = "7.jpg", Brand = michaelKors, Category = woman, Style = classic, DiscountRate = 20, SalesQuantity = 111, StockQuantity = 1011,
                    Description = "watchband : steel / technology : quartz / diameter : 38mm / shape: round / glass-type : mineral / waterproof : 5 ATM" },
                new Product() { Name = "Michael Kors MK7108", Price = 463.00m, PictureUri = "8.jpg", Brand = michaelKors, Category = woman, Style = sport, DiscountRate = 20, SalesQuantity = 112, StockQuantity = 1012,
                    Description = "watchband : steel / technology : quartz / diameter : 42mm / shape: round / glass-type : mineral / waterproof : 5 ATM" },
                new Product() { Name = "Michael Kors MKT5128", Price = 324.50m, PictureUri = "9.jpg", Brand = michaelKors, Category = woman, Style = smart, DiscountRate = 20, SalesQuantity = 113, StockQuantity = 1013,
                    Description = "watchband : steel / technology : touchscreen smartwatch technology / diameter : 43mm / shape: round / glass-type : mineral / waterproof : 5 ATM" },
                new Product() { Name = "Michael Kors MK7146", Price = 157.00m, PictureUri = "10.jpg", Brand = michaelKors, Category = man, Style = classic, DiscountRate = 20, SalesQuantity = 114, StockQuantity = 1014,
                    Description = "watchband : steel / technology : quartz / diameter : 42mm / shape: round / glass-type : mineral / waterproof : 3 ATM" },
                new Product() { Name = "Michael Kors MK8829", Price = 251.99m, PictureUri = "11.jpg", Brand = michaelKors, Category = man, Style = sport, DiscountRate = 20, SalesQuantity = 115, StockQuantity = 1015,
                    Description = "watchband : steel / technology : quartz / diameter : 45mm / shape: round / glass-type : mineral / waterproof : 10 ATM" },
                new Product() { Name = "Michael Kors MKT5134", Price = 405.99m, PictureUri = "12.jpg", Brand = michaelKors, Category = man, Style = smart, DiscountRate = 20, SalesQuantity = 116, StockQuantity = 1016,
                    Description = "watchband : steel / technology : touchscreen smartwatch technology / diameter : 44mm / shape: round / glass-type : mineral / waterproof : 3 ATM" },
                new Product() { Name = "Wesse WWL106006", Price = 64.50m, PictureUri = "13.jpg", Brand = wesse, Category = woman, Style = classic, DiscountRate = 20, SalesQuantity = 117, StockQuantity = 1017,
                    Description = "watchband : steel / technology : quartz / diameter : 30mm / shape: round / glass-type : mineral / waterproof : 3 ATM" },
                new Product() { Name = "Wesse WWL108101", Price = 75.00m, PictureUri = "14.jpg", Brand = wesse, Category = woman, Style = sport,  SalesQuantity = 118, StockQuantity = 1018,
                    Description = "watchband : steel / technology : quartz / diameter : 38mm / shape: round / glass-type : mineral / waterproof : 5 ATM" },
                new Product() { Name = "Wesse WWC200106", Price = 41.00m, PictureUri = "15.jpg", Brand = wesse, Category = woman, Style = smart,  SalesQuantity = 119, StockQuantity = 1019,
                    Description = "watchband : composite / technology : touchscreen smartwatch technology / diameter : 45mm / shape: round / waterproof : IP68" },
                new Product() { Name = "Wesse WWG202008", Price = 55.50m, PictureUri = "16.jpg", Brand = wesse, Category = man, Style = classic,  SalesQuantity = 120, StockQuantity = 1020,
                    Description = "watchband : steel / technology : quartz / diameter : 48mm / shape: round / glass-type : mineral / waterproof : 5 ATM" },
                new Product() { Name = "Wesse WWG401401M", Price = 138.99m, PictureUri = "17.jpg", Brand = wesse, Category = man, Style = sport, SalesQuantity = 121, StockQuantity = 1021,
                    Description = "watchband : steel / technology : quartz / diameter : 47mm / shape: round / glass-type : mineral / waterproof : 5 ATM" },
                new Product() { Name = "Wesse WWC200103", Price = 41.00m, PictureUri = "18.jpg", Brand = wesse, Category = man, Style = smart, SalesQuantity = 122, StockQuantity = 1022,
                    Description = "watchband : composite / technology : touchscreen smartwatch technology / diameter : 45mm / shape: round / waterproof : IP68" },
            };
            db.AddRange(products);
            await db.SaveChangesAsync();
        }
    }
}
