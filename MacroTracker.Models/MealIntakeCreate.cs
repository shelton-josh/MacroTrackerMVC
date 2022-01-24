using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Models
{
    public class MealIntakeCreate
    {
        [Required]
        [Display(Name = "Meal Plan Id")]
        public int MealPlanId { get; set; }

        [Required]
        [Display(Name = "Meal Id")]
        public int MealId { get; set; }       

        [Required]
        [Display(Name = "Meal Quantity")]
        public decimal MealQty { get; set; }
    }
}
