using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Service.DTOs
{

    public class DistributorDto
    {

        [Required]
        public int legal_card {get; set;}

        public string name {get; set;}
        [Required]
        public IEnumerable<DeviceDto> devices {get; set;}
        
    }

}