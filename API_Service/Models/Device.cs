using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Service.Models
{

    public class Device
    {

        [Key]
        public int serial_number {get; set;}
        [Required]
        public string brand {get; set;}
        [Required]
        public int electric_usage {get; set;}


        public string device_type_name { get; set; }
        [ForeignKey("device_type_name")]
        public DeviceType device_type {get; set;}

        public string client_email { get; set; }
        [ForeignKey("client_email")]
        public Client client {get; set;}

        public List<Distributor> distributors_ {get; set;}
        public List<Order> orders {get; set;}


    }

}