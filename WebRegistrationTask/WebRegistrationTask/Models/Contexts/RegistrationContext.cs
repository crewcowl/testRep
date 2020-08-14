using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebRegistrationTask.Models
{
    public class RegistrationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<UserDrinks> userDrinks { get; set; }
        public DbSet<UserColors> userColors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserColors>()
                .HasKey(t => new { t.Userid, t.Colorid });

            modelBuilder.Entity<UserColors>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.UserColors)
                .HasForeignKey(sc => sc.Userid);

            modelBuilder.Entity<UserColors>()
                .HasOne(sc => sc.Color)
                .WithMany(c => c.UserColors)
                .HasForeignKey(sc => sc.Colorid);

            modelBuilder.Entity<UserDrinks>()
                .HasKey(t => new { t.Userid, t.Drinkid });

            modelBuilder.Entity<UserDrinks>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.UserDrinks)
                .HasForeignKey(sc => sc.Userid);

            modelBuilder.Entity<UserDrinks>()
                .HasOne(sc => sc.Drink)
                .WithMany(c => c.UserDrinks)
                .HasForeignKey(sc => sc.Drinkid);
        }
        public RegistrationContext(DbContextOptions<RegistrationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            if (!Colors.Any())
            {
                Colors.Add(new Color { name = "Красный" });
                Colors.Add(new Color { name = "Синий" });
                Colors.Add(new Color { name = "Желтый" });
                this.SaveChanges();
            }
            if (!Drinks.Any())
            {
                Drinks.Add(new Drink { name = "Чай" });
                Drinks.Add(new Drink { name = "Кофе" });
                Drinks.Add(new Drink { name = "Вода" });
                Drinks.Add(new Drink { name = "Сок" });
                this.SaveChanges();
            }
            
        }
    }
}
