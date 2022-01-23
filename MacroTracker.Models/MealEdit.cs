using MacroTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Models
{
    public class MealEdit
    {
        public int MealId { get; set; }

        [Display(Name = "Meal Name")]
        public string MealName { get; set; }

        [Display(Name = "Meal Content")]
        public string MealContent { get; set; }

        public virtual Intake Intake { get; set; }

        public int IntakeQty { get; set; }

        public string IntakeDetail { get; set; }
    }
}
