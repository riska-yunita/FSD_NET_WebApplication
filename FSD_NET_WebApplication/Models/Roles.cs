using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSD_NET_WebApplication.Models;

[Table("TB_M_Roles")]
public class Roles
{
    [Column("id"), Key]
    public int Id { get; set; }
    [Column("name", TypeName = "varchar(50)")]
    public String Name { get; set; }

    public ICollection<AccountRoles>? AccountRoles { get; set; }
}
