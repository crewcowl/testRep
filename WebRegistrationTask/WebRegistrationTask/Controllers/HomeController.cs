using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebRegistrationTask.Models;

namespace WebRegistrationTask.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private RegistrationContext db;
        public HomeController(RegistrationContext context)
        {
            db = context;
        }

        [AllowAnonymous]
        public IActionResult StartPage()
        {
            return View();
        }

        public async Task<IActionResult> AdminPage(string colorDrop, string drinkDrop)
        {
            if (User.Identity.IsAuthenticated)
            {
                var Color = db.Colors.ToList();
                var Drink = db.Drinks.ToList();
                var userColors = db.userColors.ToList();
                var userDrinks = db.userDrinks.ToList();
                var users = db.Users.ToList();
                if (!String.IsNullOrEmpty(colorDrop))
                {
                    var uC = userColors.Where(c => c.Color.name.Contains(colorDrop)).ToList();
                    users = uC.Select(u => u.User).ToList();
                }

                if (!String.IsNullOrEmpty(drinkDrop))
                {

                    var uD = userDrinks.Where(d => d.Drink.name.Contains(drinkDrop)).ToList();
                    var users2 = uD.Select(u => u.User).ToList();
                    users = users.Intersect(users2).ToList();
                }



                List<UserListModel> userLists = new List<UserListModel>();
                foreach (var user in users)
                {
                    List<Color> colors = new List<Color>();
                    List<Drink> drinks = new List<Drink>();
                    foreach (var colorid in userColors.Where(s => s.User.id.ToString().Contains(user.id.ToString())))
                    {
                        Color color = db.Colors.Where(s => s.name.Contains(colorid.Color.name)).SingleOrDefault();
                        if (color != null)
                        {
                            colors.Add(color);
                        }
                    }
                    foreach (var drinkid in userDrinks.Where(s => s.User.id.ToString().Contains(user.id.ToString())))
                    {
                        Drink drink = db.Drinks.Where(s => s.name.Contains(drinkid.Drink.name)).SingleOrDefault();
                        if (drink != null)
                        {
                            drinks.Add(drink);
                        }
                    }

                    userLists.Add(new UserListModel { Users = user, Colors = colors, Drinks = drinks });
                }
                UserViewModel userViewModel = new UserViewModel { userListModels = userLists, colors = db.Colors.ToList(), drinks = db.Drinks.ToList() };
                return View(userViewModel);
            }
            return Content("У вас нет доступа к этой странице");
        }

        [AllowAnonymous]
        public IActionResult Create()
        {
            var model = new RegistrationViewModel { Colors = db.Colors.ToList(), Drinks = db.Drinks.ToList(),  };
            return View(model);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(RegistrationViewModel registrationViewModel, IEnumerable<int> colorsList, IEnumerable<int> drinksList)
        {
            if(colorsList != null)
            {
                foreach (var color in colorsList) {
                    UserColors userColor = new UserColors { Color = db.Colors.Where(s=> s.id.Equals(color)).SingleOrDefault(), User = registrationViewModel.Users };
                    db.userColors.Add(userColor);
                }
            }
            if (drinksList != null)
            {
                foreach (var drink in drinksList)
                {
                    UserDrinks userDrinks = new UserDrinks { Drink = db.Drinks.Where(s => s.id.Equals(drink)).SingleOrDefault(), User = registrationViewModel.Users };
                    db.userDrinks.Add(userDrinks);
                }
            }
            db.Users.Add(registrationViewModel.Users);
            await db.SaveChangesAsync();
            return RedirectToAction("Result");
        }
        [AllowAnonymous]
        public IActionResult Result()
        {
            return View();
        }
        
    }
}
