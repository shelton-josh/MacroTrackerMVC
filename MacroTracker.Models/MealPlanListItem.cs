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

        [Display(Name = "Total Calories")]
        public int TotalCalories { get; set; }

        [Display(Name = "Total Proteins")]
        public decimal TotalProteins { get; set; }

        [Display(Name = "Total Carbs")]
        public decimal TotalCarbs { get; set; }

        [Display(Name = "Total Fats")]
        public decimal TotalFats { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateTime { get; set; }
    }
}
