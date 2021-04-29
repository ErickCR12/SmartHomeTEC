using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Service.DTOs
{

    public class ClientDto
    {

        [Required]
        public string email {get; set;}
        [Required]
        public string name {get; set;}
        [Required]
        public string password {get; set;}
        [Required]
        public string last_name1 {get; set;}
        [Required]
        public string last_name2 {get; set;}
        [Required]
        public string country {get; set;}
        [Required]
        public string continent {get; set;}
        
    }

}