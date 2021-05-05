using System.ComponentModel.DataAnnotations;

namespace API_Service.DTOs
{

    public class DevicePerRegionDto
    {

        [Required]
        public string continent {get; set;}

        [Required]
        public string country {get; set;}

        [Required]
        public int amount {get; set;}
        
    }

}