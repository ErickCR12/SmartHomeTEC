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

        public List<Distributor> distributors {get; set;}
        public List<Order> orders {get; set;}


    }

}