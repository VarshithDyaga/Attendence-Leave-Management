using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Attendence_Leave_Management.Model
{
    public class Manager
    {

        [Key]
        public int ManagerId { get; set; }

        public string? ManagerName { get; set; }

        public string? ManagerUname { get; set; }

        public string? ManagerPassword { get; set; }

        public string ManagerEmail { get; set; } = null!;


        [ForeignKey(nameof(project))]
        public int ProjectCode { get; set; }
        [JsonIgnore]
        public virtual Project? project { get; set; }
    }
}
