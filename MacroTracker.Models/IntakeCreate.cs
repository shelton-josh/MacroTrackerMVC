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
        [Display(Name = "Meal Id")]
        public int MealId { get; set; }
      
        [Required]
        [Display(Name = "Food Quantity")]
        public decimal FoodQty { get; set; }

        [Required]
        [Display(Name = "Food Id")]
        public int FoodId { get; set; }
    }
}

