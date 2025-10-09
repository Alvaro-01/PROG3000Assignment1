using Microsoft.EntityFrameworkCore;

namespace Assignment1.Models.Repository;

public class EquipmentRepository : IEquipmentRepository
{
    private readonly FastEquipmentContext _context;

    public EquipmentRepository(FastEquipmentContext context)
    {
        _context = context;
    }

    public IEnumerable<Equipment> GetAll()
    {
        return _context.Equipments.ToList();
    }

    public Equipment GetAvailable(bool isAvailable)
    {
        return _context.Equipments.FirstOrDefault(e => e.IsAvailable == isAvailable);
    }

   
    public Equipment? FindById(int id)
    {
        return _context.Equipments.Find(id);
    }

    public void Add(Equipment equipment)
    {
        _context.Equipments.Add(equipment);
        _context.SaveChanges();
    }

    public void Update(Equipment equipment,bool isAvailable)
    {
        equipment.IsAvailable = isAvailable;
        _context.Entry(equipment).State = EntityState.Modified;
        _context.SaveChanges();
    }


    
}