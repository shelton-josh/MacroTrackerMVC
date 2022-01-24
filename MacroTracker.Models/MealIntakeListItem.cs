using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Models
{
    public class MealIntakeListItem
    {
        public int MealIntakeId { get; set; }

        [Display(Name = "Meal Plan Id")]
        public int MealPlanId { get; set; }

        [Display(Name = "Meal Id")]
        public int MealId { get; set; }

        [Display(Name = "Meal Quantity")]
        public decimal MealQty { get; set; }

        public string Meal { get; set; }
    }
}
