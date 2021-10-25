using System;
using System.ComponentModel.DataAnnotations;

namespace HometaskASP.Models
{
    public class UpdateUser
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
