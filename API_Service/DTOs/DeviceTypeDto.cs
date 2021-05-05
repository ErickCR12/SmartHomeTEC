using System.ComponentModel.DataAnnotations;

namespace API_Service.DTOs
{

    public class DeviceTypeDto
    {
        [Required]
        public string name {get; set;}
        [Required]
        public string description {get; set;}
        [Required] 
        public int warranty_months {get; set;}
    }

}