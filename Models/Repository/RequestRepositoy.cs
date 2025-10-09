using Microsoft.EntityFrameworkCore;
using Assignment1.Models;

namespace Assignment1.Models.Repository;

public class RequestRepository : IRequestRepository
{
    private readonly FastEquipmentContext _context;

    public RequestRepository(FastEquipmentContext context)
    {
        _context = context;
    }

    public IEnumerable<EquipmentRequest> GetAll()
    {
        return _context.EquipmentRequests.ToList();
    }
    public EquipmentRequest GetPending(RequestStatus status)
    {
        return _context.EquipmentRequests.FirstOrDefault(r => r.Status == status);
    }
    public EquipmentRequest? FindById(int id)
    {
        return _context.EquipmentRequests.Find(id);
    }
    public void Add(EquipmentRequest request)
    {
        _context.EquipmentRequests.Add(request);
        _context.SaveChanges();
    }
    public void UpdateStatus(EquipmentRequest request, RequestStatus status)
    {
        request.Status = status;
        _context.Entry(request).State = EntityState.Modified;
        _context.SaveChanges();
    }

}