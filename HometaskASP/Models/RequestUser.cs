﻿using System.ComponentModel.DataAnnotations;

namespace HometaskASP.Models
{
    public class RequestUser
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
