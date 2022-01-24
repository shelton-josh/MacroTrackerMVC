using MacroTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Models
{
    public class MealIntakeEdit
    {
        public int MealIntakeId { get; set; }

        [Display(Name = "Meal Name")]
        public string MealIntakeName { get; set; }

        [Display(Name = "Meal Content")]
        public string MealIntakeContent { get; set; }

        public virtual MealIntake MealIntake { get; set; }

        public int MealIntakeQty { get; set; }

        public string MealIntakeDetail { get; set; }

        public int MealId { get; set; }

        public int MealQty { get; set; }

        public int MealPlanId { get; set; }
    }
}
