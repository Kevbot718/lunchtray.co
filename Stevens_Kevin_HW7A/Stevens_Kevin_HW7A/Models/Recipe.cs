using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stevens_Kevin_HW7A.Models
{
    [Table("Recipe")]
    public class Recipe
    {
        [Key]
        public Int32 RecipeID { get; set; }

        [Display(Name = "Recipe")]
        public string RecipeName { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        public string Instructions { get; set; }

        public virtual List<DayConfig> DayConfig { get; set; }
        public virtual List<RecipeIngredientBridge> RecipeIngredientBridges { get; set; }
    }
}