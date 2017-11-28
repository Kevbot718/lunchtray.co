using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stevens_Kevin_HW7A.Models
{
    public class RecipeDateBridge
    {
        [Key, Column (Order =0)]
        public Int32 RDB { get; set; }

        [Key, Column(Order = 1)]
        public Int32 MenuNumber { get; set; }

        public DateTime MenuDate { get; set; }

        [Key, Column(Order = 2)]
        public Int32 RecipeViewModelID { get; set; }

        public virtual Date Date { get; set; }
        public virtual RecipeViewModel RecipeViewModel { get; set; }
    }
}