using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Models
{
    public class MealListItem
    {
        [Display(Name = "Meal Id")]
        public int MealId { get; set; }

        [Display(Name = "Meal Name")]
        public string MealName { get; set; }

        public int Calories { get; set; }
        public decimal Proteins { get; set; }
        public decimal Carbs { get; set; }
        public decimal Fats { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateTime { get; set; }
    }
}
