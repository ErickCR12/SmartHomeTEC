using System.ComponentModel.DataAnnotations;

namespace API_Service.DTOs
{

    public class DeviceDto
    {
        public int serial_number {get; set;}
        [Required]
        public string device_type_name {get; set;}
        [Required]
        public string brand {get; set;}
        [Required]
        public int electric_usage {get; set;}
    }

}