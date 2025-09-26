using System.ComponentModel.DataAnnotations;
namespace Assignment1.Models;

public class EquipmentRequest
{

    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter your name")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Please enter a valid email address")]
    public string? Email { get; set; }


    [Required(ErrorMessage = "Please enter a valid phone number")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "Please enter a valid role")]
    public string? Role { get; set; }

    [Required(ErrorMessage = "Please enter a valid equipment type")]
    public string? EquipmentType { get; set; }

    [Required(ErrorMessage = "Please enter request details")]
    public string? RequestDetails { get; set; }

    
    [Required(ErrorMessage = "Please enter a valid duration"), Range(1, 365, ErrorMessage = "Duration must be between 1 and 365 days")]
    public int? Duration { get; set; }

    
}