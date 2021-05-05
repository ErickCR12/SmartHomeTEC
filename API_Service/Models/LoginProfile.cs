using System.ComponentModel.DataAnnotations;

namespace API_Service.Models{

    public class LoginProfile
    {
        [Required]
        public string Username { get; set;}
        
        [Required]
        public string Password { get; set;}

        public string UserType{ get; set;}
    }
}