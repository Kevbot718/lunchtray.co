//Author: Kevin Stevens
//Date: April 14, 2017
//Assignment: Homework 7
//Description: Implement identity into expanded member tracker MVC website linked with entity framework

using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stevens_Kevin_HW7A.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    //create enum drop down list for major selection
    public enum Major { Accounting, Business_Honors, Finance, International_Business, Management, MIS, Marketing, Supply_Chain_Management, STM };

    [Table("AppUsers")]
    public class AppUser : IdentityUser
    {

        // Appuser scalar and navigational properties
        //For instance
        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First Name")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Please enter your Last name")]
        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Please specify whether this person is OK to Text")]
        [Display(Name = "Is it okay to text you?")]
        public bool OKToText { get; set; }

        [Required(ErrorMessage = "Please specify this persons major")]
        [Display(Name = "Major")]
        public Major Major { get; set; }

        //This method allows you to create a new user
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    //db context ibcluding all db sets 
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        //Add dbsets here, for instance there's one for books
        //Remember, Identity adds a db set for users, so you shouldn't add that one - you will get an error
        //public DbSet<Book> Books { get; set; }


        //Make sure that your connection string name is correct here.
        public AppDbContext()
            : base("MyDBConnection", throwIfV1Schema: false)
        {
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}