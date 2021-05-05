using System.ComponentModel.DataAnnotations;

namespace API_Service.Models
{

    public class DevicePerRegion
    {

        [Required]
        public string continent {get; set;}

        [Required]
        public string country {get; set;}

        [Required]
        public int amount {get; set;}
        
    }

}