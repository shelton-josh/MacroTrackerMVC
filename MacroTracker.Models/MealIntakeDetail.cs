using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Models
{
    public class MealIntakeDetail
    {
        [Display(Name = "Intake Id")]
        public int MealIntakeId { get; set; }

        [Display(Name = "Meal Id")]
        public int MealPlanId { get; set; }

        public DateTime DateTime { get; set; }

        [Display(Name = "Meal Quantity")]
        public decimal MealQty { get; set; }

        public MealListItem Meal { get; set; }
    }
}
