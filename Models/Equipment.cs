using System.ComponentModel.DataAnnotations.Schema;
namespace Assignment1.Models;

public class Equipment
{
    public int Id { get; set; }
    public string? Type { get; set; }
    public string? Description { get; set; }
    public bool IsAvailable { get; set; }

    [NotMapped]
    public string AvailabilityStatus => IsAvailable ? "Available" : "Not Available";
}


