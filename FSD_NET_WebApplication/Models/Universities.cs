using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSD_NET_WebApplication.Models;

[Table("TB_M_Universities")]
public class Universities
{
    [Column("id"), Key]
    public int Id { get; set; }
    [Column("name", TypeName ="varchar(100)")]
    public String Name { get; set; }

    public ICollection<Educations>? Educations { get; set; }
}
