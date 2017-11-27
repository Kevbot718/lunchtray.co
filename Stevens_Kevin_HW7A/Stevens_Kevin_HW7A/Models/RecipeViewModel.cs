using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using static Stevens_Kevin_HW7A.Models.Recipe;


namespace Stevens_Kevin_HW7A.Models
{
    [Table("RecipeViewModel")]
    public class RecipeViewModel
    {
        [Key]
        public Int32 RecipeViewModelID { get; set; }

        [Display(Name = "Recipe")]
        public String RecipeName { get; set; }

        [Display(Name = "Ingredient")]
        public String IngredientName { get; set; }

        [Display(Name = "Unit")]
        public MeasurementType MeasurementType { get; set; }

        [Display(Name = "Quantity")]
        public Int32 MeasurementQuantity { get; set; }

        [Display(Name = "Ingredient 2")]
        public String IngredientName2 { get; set; }

        [Display(Name = "Unit 2")]
        public MeasurementType MeasurementType2 { get; set; }

        [Display(Name = "Quantity 2")]
        public Int32 MeasurementQuantity2 { get; set; }

        [Display(Name = "Ingredient 3")]
        public String IngredientName3 { get; set; }

        [Display(Name = "Unit 3")]
        public MeasurementType MeasurementType3 { get; set; }

        [Display(Name = "Quantity 3")]
        public Int32 MeasurementQuantity3 { get; set; }

        [Display(Name = "Ingredient 4")]
        public String IngredientName4 { get; set; }

        [Display(Name = "Unit 4")]
        public MeasurementType MeasurementType4 { get; set; }

        [Display(Name = "Quantity 4")]
        public Int32 MeasurementQuantity4 { get; set; }

        [Display(Name = "Ingredient 5")]
        public String IngredientName5 { get; set; }

        [Display(Name = "Unit 5")]
        public MeasurementType MeasurementType5 { get; set; }

        [Display(Name = "Quantity 5")]
        public Int32 MeasurementQuantity5 { get; set; }

        [Display(Name = "Ingredient 6")]
        public String IngredientName6 { get; set; }

        [Display(Name = "Unit 6")]
        public MeasurementType MeasurementType6 { get; set; }

        [Display(Name = "Quantity 6")]
        public Int32 MeasurementQuantity6 { get; set; }

        [Display(Name = "Ingredient 7")]
        public String IngredientName7 { get; set; }

        [Display(Name = "Unit 7")]
        public MeasurementType MeasurementType7 { get; set; }

        [Display(Name = "Quantity 7")]
        public Int32 MeasurementQuantity7 { get; set; }

        [Display(Name = "Ingredient 8")]
        public String IngredientName8 { get; set; }

        [Display(Name = "Unit 8")]
        public MeasurementType MeasurementType8 { get; set; }

        [Display(Name = "Quantity 8")]
        public Int32 MeasurementQuantity8 { get; set; }

        [Display(Name = "Prep Time")]
        public Int32 PrepTime { get; set; }

        [Display(Name = "Cook Time")]
        public Int32 CookTime { get; set; }

        [Display(Name = "Total Cost")]
        public double TotalCost { get; set; }

        [Display(Name = "Notes")]
        public String Notes { get; set; }

        public String Instructions { get; set; }

        public virtual List<Recipe> Recipes { get; set; }
        public virtual Order Order { get; set; }
        public virtual List<RecipeIngredientBridge> RecipeIngredientBridges { get; set; }

    }
}