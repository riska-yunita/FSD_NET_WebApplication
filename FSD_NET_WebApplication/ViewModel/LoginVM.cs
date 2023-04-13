using System.ComponentModel.DataAnnotations;

namespace FSD_NET_WebApplication.ViewModel;

public class LoginVM
{
    [EmailAddress]
    public string Email { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
