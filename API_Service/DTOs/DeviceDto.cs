using System.ComponentModel.DataAnnotations;

namespace API_Service.DTOs
{

    public class DeviceDto
    {
        public int serial_number {get; set;}
        public string device_type_name {get; set;}
        public string brand {get; set;}
        public int price {get; set;}
        public int electric_usage {get; set;}

        public string client_email {get; set;}
    }

}