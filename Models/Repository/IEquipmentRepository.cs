namespace Assignment1.Models.Repository;

public interface IEquipmentRepository
{
    IEnumerable<Equipment> GetAll();

    IEnumerable<Equipment> GetAvailable(bool isAvailable);

    IEnumerable<Equipment> GetEquipmentByType();
    Equipment? FindById(int id);



    void Add(Equipment equipment);
    void Update(Equipment equipment, bool isAvailable);
}