using System.ComponentModel.DataAnnotations;

namespace Attendence_Leave_Management.Model
{
    public class Project
    {
        [Key]
        public int ProjectCode { get; set; }

        public string? ProjectName { get; set; }

        public string? ProjectTechnology { get; set; }

        public string? ProjectDescription { get; set; }

        public string ProjectStatus { get; set; } = null!;


    }
}
