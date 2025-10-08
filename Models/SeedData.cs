using Microsoft.EntityFrameworkCore;

namespace Assignment1.Models;

public static class SeedData
{
    public static void EnsurePopulated(IApplicationBuilder app)
    {
        FastEquipmentContext context = app.ApplicationServices.
            CreateScope().ServiceProvider
            .GetRequiredService<FastEquipmentContext>();
        context.Database.Migrate();

        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }

        if (!context.Equipments.Any())
        {
            context.Equipments.AddRange(
                new Equipment
                {
                    Type = EquipmentType.Laptop,
                    Description = "Dell XPS 13, 16GB RAM, 512GB SSD",
                    IsAvailable = true
                },
                new Equipment
                {
                    Type = EquipmentType.Phone,
                    Description = "iPhone 13 Pro, 128GB, Silver",
                    IsAvailable = true
                },
                new Equipment
                {
                    Type = EquipmentType.Tablet,
                    Description = "iPad Air, 64GB, Space Gray",
                    IsAvailable = false
                },
                new Equipment
                {
                    Type = EquipmentType.Another,
                    Description = "Samsung Galaxy Tab S7, 128GB, Black",
                    IsAvailable = true
                },
                new Equipment
                {
                    Type = EquipmentType.Laptop,
                    Description = "MacBook Pro 14-inch, M1 Pro, 16GB RAM, 512GB SSD",
                    IsAvailable = false
                },
                new Equipment
                {
                    Type = EquipmentType.Phone,
                    Description = "Google Pixel 6, 128GB, Sorta Seafoam",
                    IsAvailable = true
                }
            );
            context.SaveChanges();
        }
    }

}

