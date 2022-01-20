using MacroTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Models
{
    public class MealDetail
    {
        [Display(Name = "Meal Id")]
        public int MealId { get; set; }

        [Display(Name = "Meal Name")]
        public string MealName { get; set; }

        public string MealContent { get; set; }

        public string IntakeDetail { get; set; }
      
        public decimal IntakeQty { get; set; }
    }
}
