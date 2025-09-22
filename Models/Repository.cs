namespace Assignment1.Models;

public static class Repository
{
    private static List<EquipmentRequest> requests = new List<EquipmentRequest>();

    public static IEnumerable<EquipmentRequest> Requests => requests;

    public static void AddRequest(EquipmentRequest request)
    {
        Console.WriteLine("Adding request for: " + request.Name);
        requests.Add(request);
    }
}