using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSD_NET_WebApplication.Models;

[Index("Email", IsUnique = true)]
[Index("PhoneNumber", IsUnique = true)]
[Table("TB_M_Employees")]
public class Employees
{
    [Column("nik", TypeName = "char(5)"), Key]
    public String NIK { get; set; }
    [Column("first_name", TypeName = "varchar(50)")]
    public string FirstName { get; set; }
    [Column("last_name", TypeName = "varchar(50)")]
    public string? LastName { get; set; }
    [Column("birthdate", TypeName = "datetime")]
    public DateTime Birthdate { get; set; }
    [Column("gender")]
    public Gender Gender { get; set; }
    [Column("hiring_date", TypeName = "datetime")]
    public DateTime HiringDate { get; set; }
    [Column("email", TypeName = "varchar(50)")]
    public String Email { get; set; }
    [Column("phone_number", TypeName = "varchar(20)")]
    public String PhoneNumber { get; set; }

    public Profilings? Profilings { get; set; }
    public Accounts? Accounts { get; set; }
}

public enum Gender{Male,Female}