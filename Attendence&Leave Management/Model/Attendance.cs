using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Attendence_Leave_Management.Model
{
    public class Attendance
    {
        [Key]
        public int AttendenceId { get; set; }

        [ForeignKey(nameof(employee))]
        public int EmployeeId { get; set; }
        [JsonIgnore]
        public Employees? employee { get; set; }
        [ForeignKey(nameof(project))]
        public int ProjectCode { get; set; }
        [JsonIgnore]
        public Project? project { get; set; }

        public string Employeename { get; set; } = null!;

        public DateTime Date { get; set; }

        public string EmployeeRole { get; set; } = null!;

        public string? PresenceStatus { get; set; }

        public string? ApprovalStatus { get; set; }
    }
}
