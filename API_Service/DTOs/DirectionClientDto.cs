using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Service.DTOs
{

    public class DirectionClientDto
    {

        [Required]
        public string client_email {get; set;}
        [Required]
        public string direction {get; set;}
        
    }

}