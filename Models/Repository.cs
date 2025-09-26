namespace Assignment1.Models;

public static class Repository
{
    private static List<EquipmentRequest> requests = new List<EquipmentRequest>();

    public static IEnumerable<EquipmentRequest> Requests => requests;

    private static List<Equipment> equipmentList = new List<Equipment>
    {
        new Equipment { Id = 1, Type = "Laptop", Description = "Dell XPS 13", IsAvailable = true },
        new Equipment { Id = 2, Type = "Projector", Description = "Epson EX3260", IsAvailable = false },
        new Equipment { Id = 3, Type = "Camera", Description = "Canon EOS Rebel T7", IsAvailable = true },
        new Equipment { Id = 4, Type = "Microphone", Description = "Blue Yeti USB Microphone", IsAvailable = true },
        new Equipment { Id = 5, Type = "Tablet", Description = "iPad Pro 11-inch", IsAvailable = false }
    };

    public static IEnumerable<Equipment> EquipmentList => equipmentList;

    public static void AddRequest(EquipmentRequest request)
    {
        Console.WriteLine("Adding request for: " + request.Name);
        requests.Add(request);
    }
}