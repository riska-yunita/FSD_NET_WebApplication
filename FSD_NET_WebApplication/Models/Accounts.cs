using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSD_NET_WebApplication.Models;

[Table("TB_M_Accounts")]
public class Accounts
{
    [Column("employee_nik", TypeName = "char(5)"), Key]
    public String EmployeeNIK { get; set; }

    [Column("password", TypeName = "varchar(255)")]
    public String Password { get; set; }

    public Employees? Employees { get; set; }
    public ICollection<AccountRoles>? AccountRoles { get; set; }
}
