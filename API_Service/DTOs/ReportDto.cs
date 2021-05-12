using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Service.DTOs
{

    public class ReportDto
    {

        [Required]
        public string string_value {get; set;}
        [Required]
        public int numerical_value {get; set;}
        
    }

}