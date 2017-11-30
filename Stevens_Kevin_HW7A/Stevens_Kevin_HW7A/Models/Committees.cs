//Author: Kevin Stevens
//Date: April 14, 2017
//Assignment: Homework 7
//Description: Implement identity into expanded member tracker MVC website linked with entity framework

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stevens_Kevin_HW7A.Models
{
    [Table("Committees")]

    //create scalar and navigational properties
    public class Committee
    {
        [Key]
        public Int32 CommitteeID { get; set; }

        [Required(ErrorMessage = "Committee name required")]
        [Display(Name = "Name")]
        public string CommitteeName { get; set; }

        public virtual List<Event> Events { get; set; }
    }
}