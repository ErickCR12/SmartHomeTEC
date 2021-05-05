using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Service.Models
{

    public class Region
    {

        [Required]
        public string continent {get; set;}
        [Required]
        public string country {get; set;}

        public int amount {get; set;}
        
    }

}