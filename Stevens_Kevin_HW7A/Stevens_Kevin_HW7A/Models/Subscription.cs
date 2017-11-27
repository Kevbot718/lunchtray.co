using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stevens_Kevin_HW7A.Models
{
    public enum Meal { Regular, Vegetarian, Cold }

    [Table("Subscription")]
    public class Subscription
    {

        [Key]
        public Int32 SubscriptionID { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Subscriber First name")]
        public string FirstName { get; set; }

        [Display(Name = "Subscriber Last name")]
        public string LastName { get; set; }

        [Display(Name = "Meal Selection")]
        public Meal Meal { get; set; }

        public virtual List<Ingredient> Ingredients { get; set; }
    }
}