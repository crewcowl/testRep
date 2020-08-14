using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRegistrationTask.Models
{
    public class User
    {
        public int id { set; get; }
        public string name { set; get; }
        public string surname { set; get; }
        public DateTime birthday { set; get; }
        public string phone { set; get; }
        public List<UserColors> UserColors { set; get; }
        public List<UserDrinks> UserDrinks { set; get; }

        public User()
        {
            UserColors = new List<UserColors>();
            UserDrinks = new List<UserDrinks>();
        }
    }
}
