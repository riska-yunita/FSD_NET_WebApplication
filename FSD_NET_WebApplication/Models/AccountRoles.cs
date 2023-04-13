using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSD_NET_WebApplication.Models;

[Table("TB_TR_Account_Roles")]
public class AccountRoles
{
    [Column("id"), Key]
    public int Id { get; set; }

    [Column("account_nik", TypeName = "char(5)")]
    public String AccountNIK { get; set; }

    [Column("role_id")]
    public int RoleId { get; set; }

    public Accounts? Accounts { get; set; }
    public Roles? Roles { get; set; }
}