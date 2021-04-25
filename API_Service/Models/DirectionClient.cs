using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Service.Models
{

    public class DirectionClient
    {

        [Key]
        public string direction {get; set;}
        
    }

}