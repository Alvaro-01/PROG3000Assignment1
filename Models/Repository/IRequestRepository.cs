namespace Assignment1.Models.Repository;

public interface IRequestRepository
{
    IEnumerable<EquipmentRequest> GetAll();

    EquipmentRequest GetPending(RequestStatus status);

    EquipmentRequest? FindById(int id);

    void Add(EquipmentRequest request);
    void UpdateStatus(EquipmentRequest request, RequestStatus status);
}
    