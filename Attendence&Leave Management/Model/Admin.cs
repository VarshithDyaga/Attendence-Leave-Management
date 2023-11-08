using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attendence_Leave_Management.Model
{
    public class Admin:AdminLogin
    {
        [Key]
        public int AdminId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
    public class AdminLogin
    {
        [Required] 
        public string UserName { get; set; }
        [Required]
       
        
        [DataType(DataType.Password)]


        public string Password { get; set; }
    }

}
