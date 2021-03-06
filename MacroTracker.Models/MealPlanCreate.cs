using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Models
{
    public class MealPlanCreate
    {
        [Required]
        [Display(Name = "Date")]
        public DateTime DateTime { get; set; }

        [Required]
        [Display(Name = "Meal Plan Id")]
        public int MealPlanId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string MealPlanName { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string MealPlanContent { get; set; }

        public List<MealComponent> Meal { get; set; }
    }
}
