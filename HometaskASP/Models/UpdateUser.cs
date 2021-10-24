using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HometaskASP.Models
{
    public class UpdateUser
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
