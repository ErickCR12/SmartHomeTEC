using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Service.Models
{

    public class Client
    {

        [Key]
        public string email {get; set;}
        [Required]
        public string name {get; set;}
        [Required]
        public string password {get; set;}
        [Required]
        public string last_name1 {get; set;}
        [Required]
        public string last_name2 {get; set;}
        [Required]
        public string country {get; set;}
        [Required]
        public string continent {get; set;}

        public List<Order> orders {get; set;}

        public List<Device> devices {get; set;}

        public List<DirectionClient> directions {get; set;}
        
    }

}