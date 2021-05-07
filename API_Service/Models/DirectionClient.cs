using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Service.Models
{

    public class DirectionClient
    {

        [Key]
        public string client_email {get; set;}
        [Key]
        public string direction {get; set;}
        
    }

}