using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stevens_Kevin_HW7A.Models
{
    public class DayConfig
    {
        [Key]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public MenuType MenuType { get; set; }

        public Int32 RecipeID { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual List<Order> Order { get; set; }

    }
}