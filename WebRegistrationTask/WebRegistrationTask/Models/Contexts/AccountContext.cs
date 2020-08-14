using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRegistrationTask.Models.Authenticate;

namespace WebRegistrationTask.Models.Contexts
{
    public class AccountContext : DbContext
    {
        public DbSet<AuthenticateUser> Logins { get; set; }

        public AccountContext(DbContextOptions<AccountContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            
            if (!Logins.Any())
            {
                Logins.Add(new AuthenticateUser { Login = "root", Password = "root" });
                this.SaveChanges();
            }
        }
    }
}
