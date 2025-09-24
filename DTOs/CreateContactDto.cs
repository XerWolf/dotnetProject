using System.ComponentModel.DataAnnotations;


namespace ContactsApi.DTOs;

public class CreateContactDto
{
    [Required]
    [StringLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string LastName { get; set; } = string.Empty;

    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; } = string.Empty;

    [Phone]
    [StringLength(15)]
    public string Phone { get; set; } = string.Empty;

    
}