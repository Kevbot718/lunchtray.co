using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stevens_Kevin_HW7A.Models
{

    public enum MenuType { Regular, Cold, Vegetarian};
    public enum PortionSize { PreSchool, Elementary, Adult};


    public class Order
    {
        
        [Key]
        public Int32 OrderID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public MenuType Type { get; set; }

        public PortionSize PortionSize { get; set; }


        public virtual List<CustomerOrderBridge> CustomerOrderBridges { get; set; }
        public virtual DayConfig DayConfig { get; set; }
    }
}