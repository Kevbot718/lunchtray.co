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

        [Display(Name = "Prep Time")]
        public Int32 PrepTime { get; set; }

        [Display(Name = "Cook Time")]
        public Int32 CookTime { get; set; }

        [Display(Name = "Total Cost")]
        public double TotalCost { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        public Int32 InstructionID { get; set; }

        public virtual Order Order { get; set; }
        public virtual List<RecipeIngredientBridge> RecipeIngredientBridges { get; set; }
        public virtual List<Instruction> Instructions { get; set; }

    }
}