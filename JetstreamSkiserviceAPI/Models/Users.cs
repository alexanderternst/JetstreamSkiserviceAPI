﻿using System.ComponentModel.DataAnnotations;

namespace JetstreamSkiserviceAPI.Models
{
    public class Users
    {
        [Key]
        public int user_id { get; set; }

        [StringLength(255)]
        public string username { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        public int counter { get; set; }
    }
}