using System.ComponentModel.DataAnnotations;

namespace JelaLingo.Service.DTOs.Users;

public class UserForUpdateDto
{
    [Required(ErrorMessage = "FirstName is required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "LastName is required")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; }
}
