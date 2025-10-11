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

    

    public IEnumerable<Equipment> GetAvailable(bool isAvailable)
    {
        return _context.Equipments.Where(e => e.IsAvailable == isAvailable).ToList();
    }

    public IEnumerable<Equipment> GetEquipmentByType()
    {
        return _context.Equipments.OrderBy(e => e.Type).ToList();
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