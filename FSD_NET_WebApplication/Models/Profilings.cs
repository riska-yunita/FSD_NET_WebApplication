using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSD_NET_WebApplication.Models;

[Table("TB_TR_Profilings")]
public class Profilings
{
    [Column("employee_nik", TypeName = "char(5)"), Key]
    public String EmployeeNIK { get; set; }

    [Column("education_id")]
    public int EducationId { get; set; }

    public Employees? Employees { get; set; }
    public Educations? Educations { get; set; }

}
