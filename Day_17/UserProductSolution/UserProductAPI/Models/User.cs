﻿using System.ComponentModel.DataAnnotations;

namespace UserProductAPI.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] Key { get; set; }
        public string? Role { get; set; }
    }
}
