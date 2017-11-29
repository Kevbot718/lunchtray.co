using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stevens_Kevin_HW7A.Models
{
    public class Date
    {
        [Key]
        public Int32 MenuNumber { get; set; }

        [Display (Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime MenuDate {get; set;}


        public virtual List<RecipeDateBridge> RDB { get; set; }
       
    }
}