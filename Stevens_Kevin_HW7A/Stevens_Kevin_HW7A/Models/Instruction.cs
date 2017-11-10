using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stevens_Kevin_HW7A.Models
{
    public class Instruction
    {
        [Key]
        public Int32 InstructionID { get; set; }

        public Int32 RecipeId { get; set; }

        [Display(Name = "Instruction Number")]
        public string Number { get; set; }

        [Display(Name = "Instruction Text")]
        public string InstructionText { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}