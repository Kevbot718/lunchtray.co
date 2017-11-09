using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stevens_Kevin_HW7A.Models
{
    [Table("Ingredients")]

    //create scalar and navigational properties
    public class Ingredient
    {
        [Key]
        public Int32 IngredientID { get; set; }

        [Display(Name = "Ingredient Name")]
        public string IngredientName { get; set; }

        public virtual List<RecipeIngredientBridge> RecipeIngredientBridges { get; set; }
    }
}