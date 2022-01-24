using MacroTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Models
{
    public class MealPlanEdit
    {
        public int MealPlanId { get; set; }

        [Display(Name = "Name")]
        public string MealPlanName { get; set; }

        [Display(Name = "Content")]
        public string MealPlanContent { get; set; }

        public virtual MealIntake MealIntake { get; set; }

        public int MealIntakeQty { get; set; }

        public string MealIntakeDetail { get; set; }
    }
}
