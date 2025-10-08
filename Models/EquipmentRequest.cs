using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Assignment1.Models;

public enum RequestStatus
{
    Pending,
    Accepted,
    Denied
}


public enum UserRole{
    Student,
    Professor
}
public class EquipmentRequest
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter your name")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Please enter a valid email address"), EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string? Email { get; set; }


    [Required(ErrorMessage = "Please enter a valid phone number")]
    [Phone(ErrorMessage = "Please enter a valid phone number")]
    [MinLength(10, ErrorMessage = "Phone number must be at least 10 digits")]
    [MaxLength(10, ErrorMessage = "Phone number cannot exceed 10 digits")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "Please enter a valid role")]
    public UserRole Role { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Duration must be greater than 0")]
    public int? DurationDays { get; set; }

    [Required(ErrorMessage = "Please select equipment")]
    [ForeignKey("Equipment")]
    public int? EquipmentId { get; set; }

    public RequestStatus Status { get; set; } = RequestStatus.Pending;

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;


}