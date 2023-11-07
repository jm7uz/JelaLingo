using JelaLingo.Domain.Commons;

namespace JelaLingo.Domain.Entities;

public class Admin : Auditable
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}
