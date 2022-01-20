using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Models
{
    public class IntakeCreate
    {      
        [Required]   
        public int MealId { get; set; }
      
        [Required]
        public decimal FoodQty { get; set; }

        [Required]
        public int FoodId { get; set; }
    }
}

