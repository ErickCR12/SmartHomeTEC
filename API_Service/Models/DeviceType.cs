using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Service.Models
{

    public class DeviceType
    {
        [Key]
        public string name {get; set;}
        [Required]
        public string description {get; set;}
        [Required]
        public int warranty_months {get; set;}

        public List<Device> devices {get; set;}
    }

}