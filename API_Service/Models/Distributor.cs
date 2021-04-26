using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Service.Models
{

    public class Distributor
    {

        [Key]
        public int legal_card {get; set;}
        [Required]
        public string name {get; set;}
        [Required]
        public string country {get; set;}
        [Required]
        public string continent {get; set;}
        public List<Device> devices_ {get; set;}
        
    }

}