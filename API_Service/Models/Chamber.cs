using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Service.Models
{

    public class Chamber
    {

        [Key]
        public string name {get; set;}
        
    }

}