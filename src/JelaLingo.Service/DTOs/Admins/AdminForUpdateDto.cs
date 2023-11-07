using System.ComponentModel.DataAnnotations;

namespace JelaLingo.Service.DTOs.Admins;

public class AdminForUpdateDto
{
    [Required(ErrorMessage = "FirstName is required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "LastName is required")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Role is required")]
    public string Role { get; set; }
}
