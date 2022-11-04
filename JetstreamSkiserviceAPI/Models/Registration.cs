﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JetstreamSkiserviceAPI.Models
{
    public class Registration
    {
        [Key]
        public int id { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        public string phone { get; set; }

        public DateTime create_date { get; set; }

        public DateTime pickup_date { get; set; }

        //[NotMapped]
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public Service Service { get; set; }
    }
}
