using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRegistrationTask.Models
{
    public class UserDrinks
    {
        public int Userid { set; get; }
        public User User { get; set; }

        public int Drinkid { get; set; }
        public Drink Drink { get; set; }
    }
}
