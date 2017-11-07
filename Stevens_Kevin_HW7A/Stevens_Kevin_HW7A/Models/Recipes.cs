using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stevens_Kevin_HW7A.Models
{
    [Table("Recipes")]

    //create scalar and navigational properties
    public class Recipe
    {
        [Key]
        public Int32 RecipeID { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Ingredient")]
        public string Ingredient { get; set; }

        [Display(Name = "Ingredient 2")]
        public string Ingredient2 { get; set; }

        [Display(Name = "Ingredient 3")]
        public string Ingredient3 { get; set; }

        [Display(Name = "Work Instructions")]
        public string WorkInstructions { get; set; }

        public virtual List<Ingredient> Ingredients { get; set; }
    }
}