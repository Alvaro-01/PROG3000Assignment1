using Microsoft.EntityFrameworkCore;
namespace Assignment1.Models;

public class FastEquipmentContext : DbContext
{
    public FastEquipmentContext(DbContextOptions<FastEquipmentContext> options) :
    base(options){}

    public DbSet<Equipment> Equipments => Set<Equipment>();

    public DbSet<EquipmentRequest> EquipmentRequests => Set<EquipmentRequest>();
}