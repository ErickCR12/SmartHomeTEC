using System.ComponentModel.DataAnnotations;

namespace API_Service.DTOs
{

    public class DevicesPerUserDto
    {

        [Required]
        public double amountDevices {get; set;}
        [Required]
        public double amountClients {get; set;}
        [Required]
        public double amountDevicesPerUser {get; set;}
        
    }

}