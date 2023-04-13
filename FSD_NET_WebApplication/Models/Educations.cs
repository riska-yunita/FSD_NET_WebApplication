using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSD_NET_WebApplication.Models;

[Table("TB_M_Educations")]
public class Educations
{
    [Column("id"), Key]
    public int Id { get; set; }

    [Column("major", TypeName = "varchar(100)")]
    public String Major { get; set; }

    [Column("degree", TypeName = "varchar(100)")]
    public String Degree { get; set; }

    [Column("gpa", TypeName = "decimal(3,2)")]
    public double GPA { get; set; }

    [Column("university_id")]
    public int UniversityId { get; set; }

    public Universities? Universities { get; set; }

    public Profilings? Profilings { get; set; }
}
