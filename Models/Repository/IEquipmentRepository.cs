namespace Assignment1.Models.Repository;

public interface IEquipmentRepository
{
    IEnumerable<Equipment> GetAll();

    Equipment GetAvailable(bool isAvailable);
    Equipment? FindById(int id);

    void Add(Equipment equipment);
    void Update(Equipment equipment, bool isAvailable);
}