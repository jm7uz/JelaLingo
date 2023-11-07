using System.ComponentModel.DataAnnotations;

namespace JelaLingo.Service.DTOs.Users;

public class UserForCreationDto
{
    [Required(ErrorMessage = "FirstName is required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "LastName is required")]
    public string LastName { get; set; }
    public string Username { get; set; }

    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(8), MaxLength(32)]
    public string Password { get; set; }
}
