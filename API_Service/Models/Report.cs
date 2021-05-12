using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Service.Models
{

    public class Report
    {

        [Required]
        public string string_value {get; set;}
        [Required]
        public int numerical_value {get; set;}
        
    }

}