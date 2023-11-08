using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Attendence_Leave_Management.Model
{
    public class Leaves
    {
        [Key]
        public int LeaveId { get; set; }

        [ForeignKey(nameof(employee))]
        public int? EmployeeId { get; set; }
        [JsonIgnore]
        public virtual Employees? employee { get; set; }


        [ForeignKey(nameof(project))]
        public int ProjectCode { get; set; }
        [JsonIgnore]
        public virtual Project? project { get; set; }



        public string EmployeeName { get; set; } = null!;

        public string EmployeeRole { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? LeaveDescription { get; set; }

        public string LeaveStatus { get; set; } = null!;
    }
}
