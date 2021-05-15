using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Service.Models
{

    public class DeviceState
    {

        [Key]
        public int device_serial_number { get; set; }
        [Key]
        public string action { get; set; }
        public int minutes_action {get; set;}
        [Key]
        public DateTime date {get; set;}
        [Key]
        public string time {get; set;}

        [ForeignKey("device_serial_number")]
        public Device device {get; set;}


    }

}