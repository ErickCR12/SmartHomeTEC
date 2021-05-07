using System.ComponentModel.DataAnnotations;

namespace API_Service.Models
{

    public class DevicesPerUser
    {

        [Required]
        public double amountDevices {get; set;}
        [Required]
        public double amountClients {get; set;}
        [Required]
        public double amountDevicesPerUser {get; set;}
        
    }

}