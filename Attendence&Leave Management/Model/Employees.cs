using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Attendence_Leave_Management.Model
{
    public class Employees:EmployeeLogin
    {

        [Key]
        public int EmployeeId { get; set; }


        [ForeignKey(nameof(project))]
        public int? ProjectCode { get; set; }

        [JsonIgnore]
        public virtual Project? project { get; set; }


        public string? EmployeeName { get; set; }

        public string? EmployeeUname { get; set; }

        public string? EmployeePassword { get; set; }

        public string EmployeeEmail { get; set; } = null!;

        public string? EmployeeRole { get; set; }

        [ForeignKey(nameof(manager))]
        public int? ManagerId { get; set; }
        [JsonIgnore]
        
        public virtual Manager? manager { get; set; }
    }
    public class EmployeeLogin
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DefaultValue("Empl@123")]
        public string? Password { get; set; }
    }
}
