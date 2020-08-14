using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebRegistrationTask.Models
{
    public class UserListModel
    {
        public User Users { get; set; }
        public IEnumerable<Color> Colors { get; set; }
        public IEnumerable<Drink> Drinks { get; set; }
    }
}
