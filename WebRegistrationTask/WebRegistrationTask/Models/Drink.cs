using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRegistrationTask.Models
{
    public class Drink
    {
        public int id { set; get; }
        public string name { set; get; }

        public List<UserDrinks> UserDrinks { set; get; }

        public Drink ()
        {
            UserDrinks = new List<UserDrinks>();
        }
    }
}
