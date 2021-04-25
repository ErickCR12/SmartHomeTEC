using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Service.Models
{

    public class Order
    {

        [Key]
        public int consecutive {get; set;}
        [Required]
        public int bill_number {get; set;}
        [Required]
        public int price {get; set;}
        [Required]
        [Column(TypeName="Date")]
        public DateTime purchase_date {get; set;}
        [Required]
        public string purchase_time {get; set;}

    }

}