using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stevens_Kevin_HW7A.Models
{
    public class Customer
    {
        [Key]
        public Int32 CustomerID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "School")]
        public string SchoolName { get; set; }

        [Display(Name = "Default Menu Type")]
        public MenuType Default { get; set; }

        [Display(Name = "Nickname")]
        public string Nickname { get; set; }

        public virtual List<CustomerOrderBridge> CustomerOrderBridges { get; set; }

    }
}