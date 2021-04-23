using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Service.Models
{

    public class DeviceType
    {
        [Key]
        public string Name {get; set;}
        [Required]
        public string Description {get; set;}
        [Required]
        public int WarrantyMonths {get; set;}

        public List<Device> Devices {get; set;}
    }

}