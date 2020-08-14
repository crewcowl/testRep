using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRegistrationTask.Models
{
    public class UserViewModel
    {
        public string ColorName { get; set; }
        public IEnumerable<UserListModel> userListModels { get; set; }
        public IEnumerable<Color> colors { get; set; }
        public IEnumerable<Drink> drinks { get; set;}
    }
}
