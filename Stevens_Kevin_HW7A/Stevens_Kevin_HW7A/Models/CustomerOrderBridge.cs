using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stevens_Kevin_HW7A.Models
{
    public class CustomerOrderBridge
    {
        [Key, Column(Order = 0)]
        public Int32 CustomerID { get; set; }

        [Key, Column(Order = 1)]
        public Int32 OrderID { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Order Order { get; set; }

    }
}