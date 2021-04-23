using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Service.Models
{

    public class Device
    {

        [Key]
        public int SerialNumber {get; set;}
        [Required]
        public string Brand {get; set;}
        [Required]
        public int ElectricUsage {get; set;}

        public string DeviceTypeName {get; set;}
        public DeviceType DeviceType {get; set;}
    }

}