using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stevens_Kevin_HW7A.Models
{
   
    public enum MenuType { Reg, Cold, Veg };

    [Table("Order")]

    public class Order
    {
        [Key]
        public Int32 OrderID { get; set; }

        [Display(Name = "Menu")]
        public string Menu { get; set; }

        [Display(Name = "Menu Type")]
        public MenuType MenuType { get; set; }

        [Display(Name = "Serving Size")]
        public string ServingSize { get; set; }

        [Display(Name = "Monday")]
        public string Monday { get; set; }

        [Display(Name = "Tuesday")]
        public string Tuesday { get; set; }

        [Display(Name = "Wednesday")]
        public string Wednesday { get; set; }

        [Display(Name = "Thursday")]
        public string Thursday { get; set; }

        [Display(Name = "Friday")]
        public string Friday { get; set; }


        public virtual List<Ingredient> Ingredients { get; set; }
    }
}