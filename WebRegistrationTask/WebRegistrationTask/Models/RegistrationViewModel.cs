using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRegistrationTask.Models
{
    public class RegistrationViewModel
    {
        public User Users { get; set; }
        public IEnumerable<Color> Colors { get; set; }
        public IEnumerable<Drink> Drinks { get; set; }
        public IEnumerable<UserDrinks> UserDrinks { get; set; }
        public IEnumerable<UserColors> UserColors { get; set; }


    }
}
