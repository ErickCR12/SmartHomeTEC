using System.ComponentModel.DataAnnotations;

namespace API_Service.DTOs{

    public class NumericalDto
    {
        [Required]
        public int numerical_value { get; set;}

    }
}