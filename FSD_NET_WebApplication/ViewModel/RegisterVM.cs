using Microsoft.EntityFrameworkCore.Metadata.Internal;
using FSD_NET_WebApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace FSD_NET_WebApplication.ViewModel;

public class RegisterVM
{
    [StringLength(5)]
    public String NIK { get; set; }

    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    [Display(Name = "Birth Date")]
    public DateTime Birthdate { get; set; }

    public Gender Gender { get; set; }

    [EmailAddress]
    public String Email { get; set; }

    [Display(Name = "Phone Number"), Phone]
    public String PhoneNumber { get; set; }
    public string Major { get; set; }
    public string Degree { get; set; }

    [Range(0,4, ErrorMessage ="The {0} Tidak boleh kurang dari {1} dan lebih dari {2}")]
    public double GPA { get; set; }

    [Display(Name = "University Name")]
    public String UniversityName { get; set; }

    [DataType(DataType.Password), StringLength(255, ErrorMessage ="The {0} must be at least {2} characters long", MinimumLength =8)]
    [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Password must be at least 8 characters and contain uppercase, lowercase, number and special character(!@#$^&*)" )]
    public string Password { get; set; }

    [DataType(DataType.Password), Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
    public string ConfirmPassword { get; set; }
}
