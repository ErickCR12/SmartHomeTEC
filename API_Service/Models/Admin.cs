using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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