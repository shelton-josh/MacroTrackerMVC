using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Models
{
    public class MealPlanListItem
    {
        [Display(Name = "Meal Plan Id")]
        public int MealPlanId { get; set; }

        [Display(Name = "Meal Plan Name")]
        public string MealPlanName { get; set; }

        public int TotalCalories { get; set; }
        public decimal TotalProteins { get; set; }
        public decimal TotalCarbs { get; set; }
        public decimal TotalFats { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateTime { get; set; }
    }
}
