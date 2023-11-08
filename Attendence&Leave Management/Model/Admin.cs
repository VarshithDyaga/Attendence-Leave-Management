using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Attendence_Leave_Management.Model
{

    public class Admin : AdminLoginModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        public string? Name { get; set; }

        [Required]
        [EmailAddress]

        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]


        public string Password { get; set; }
    }

    public class AdminLoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        // [DataType(DataType.Password)]

        public string Password { get; set; }
    }


}
