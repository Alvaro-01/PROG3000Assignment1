using Microsoft.EntityFrameworkCore;

namespace Assignment1.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new FastEquipmentContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<FastEquipmentContext>>()))
        {
            // Look for any equipment.
            if (context.Equipments.Any() && context.EquipmentRequests.Any())
            {
                return;   // DB has been seeded
            }

            context.Equipments.AddRange(
                new Equipment
                {
                    Type = EquipmentType.Laptop,
                    Description = "A portable computer.",
                    IsAvailable = true
                },
                new Equipment
                {
                    Type = EquipmentType.Phone,
                    Description = "A mobile device for communication.",
                    IsAvailable = false
                },
                new Equipment
                {
                    Type = EquipmentType.Tablet,
                    Description = "A handheld touchscreen device.",
                    IsAvailable = true
                },

                new Equipment
                {
                    Type = EquipmentType.Another,
                    Description = "Other types of equipment.",
                    IsAvailable = true
                },

                new Equipment
                {
                    Type = EquipmentType.Laptop,
                    Description = "A high-performance laptop for gaming.",
                    IsAvailable = false
                },
                new Equipment
                {
                    Type = EquipmentType.Phone,
                    Description = "A smartphone with a large display.",
                    IsAvailable = true
                }
            );

            context.EquipmentRequests.AddRange(
                new EquipmentRequest
                {
                    Name = "Alice Johnson",
                    Email = "Alice@gmail.com",
                    Phone = "1234567890",
                    Role = UserRole.Student,
                    EquipmentId = 1,
                    DurationDays = 5,
                    Status = RequestStatus.Pending,
                    CreatedAt = DateTime.Now
                }
                
            );


            context.SaveChanges();
        }
    }

}

