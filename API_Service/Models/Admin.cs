using System.ComponentModel.DataAnnotations;

namespace API_Service.Models
{

    public class Admin
    {

        [Key]
        public string username {get; set;}
        [Required]
        public string password {get; set;}
        
    }

}