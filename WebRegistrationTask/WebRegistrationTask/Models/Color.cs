using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRegistrationTask.Models
{
    public class Color
    {
        public int id { set; get; }
        public string name { set; get; }

        public List<UserColors> UserColors { set; get; }

        public Color ()
        {
            UserColors = new List<UserColors>();
        }

    }
}
