using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Service.DTOs
{

    public class DeviceStateDto
    {

        [Required]
        public int device_serial_number { get; set; }
        [Required]
        public string action { get; set; }
        public int minutes_action {get; set;}
        [Required]
        public string date {get; set;}
        [Required]
        public string time {get; set;}

    }

}