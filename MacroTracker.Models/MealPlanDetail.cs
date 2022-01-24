using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Models
{
    public class MealPlanDetail
    {
        [Display(Name = "Id")]
        public int MealPlanId { get; set; }

        [Display(Name = "Name")]
        public string MealPlanName { get; set; }

        [Display(Name = "Contains")]
        public string MealPlanContent { get; set; }

        public string MealIntakeDetail { get; set; }

        public decimal MealIntakeQty { get; set; }
    }
}
