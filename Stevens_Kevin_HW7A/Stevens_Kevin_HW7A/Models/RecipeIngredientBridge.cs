﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Stevens_Kevin_HW7A.Models
{
    public enum MeasurementType { Slice, Oz, PC, Stick, Staple, };

    public class RecipeIngredientBridge
    {
        [Key, Column(Order = 0)]
        public Int32 RecipeID { get; set; }

        [Key, Column(Order = 1)]
        public Int32 IngredientID { get; set; }

        [Display(Name = "Ingredient Name")]
        public string IngredientName { get; set; }

        public MeasurementType MeasurementType { get; set; }

        public double MeasurementQuantity { get; set; }

        public double ElementaryMultiplier { get; set; }

        public double AdultMultiplier { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual Ingredient Ingredient { get; set; }


    }
}