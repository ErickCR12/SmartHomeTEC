using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Service.DTOs
{

    public class OrderDto
    {
        public int consecutive {get; set;}
        public int bill_number {get; set;}
        [Required]
        public int price {get; set;}
        [Required]
        [Column(TypeName="Date")]
        public string purchase_date {get; set;}
        [Required]
        public string purchase_time {get; set;}
        [Required]
        public string client_email { get; set; }
        [Required]
        public int device_serial_number { get; set; }

    }

}