using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Service.DTOs
{

    public class RegionDto
    {

        [Required]
        public string continent {get; set;}
        [Required]
        public string country {get; set;}

        public int amount {get; set;}
        
    }

}