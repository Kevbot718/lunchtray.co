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
    [Table("Events")]

    //create scalar and navigational properties
    public class Event
    {
        [Key]
        public Int32 EventID { get; set; }

        [Required(ErrorMessage = "Event title required")]
        [Display(Name = "Event Title")]
        public string EventTitle { get; set; }

        [Required(ErrorMessage = "Valid date required")]
        [Display(Name = "Event Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Event location required")]
        [Display(Name = "Event Location")]
        public string EventLocation { get; set; }

        [Required(ErrorMessage = "Please specify whether this event is exclusive to members")]
        [Display(Name = "Members only?")]
        public bool MembersOnly { get; set; }

        public virtual Committee Committee { get; set; }
        public virtual List<AppUser> Users { get; set; }
    }
}