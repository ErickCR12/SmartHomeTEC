using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Service.Models
{

    public class Chamber
    {

        [Key]
        public string name {get; set;}

        public string client_email { get; set; }
        [ForeignKey("client_email")]
        public Client client {get; set;}
        
    }

}