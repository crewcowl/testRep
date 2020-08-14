using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRegistrationTask.Models
{
    public class UserColors
    {
        public int Userid { set; get; }
        public User User { get; set; }

        public int Colorid { get; set; }
        public Color Color { get; set; }
    }
}
