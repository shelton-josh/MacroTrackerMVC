using MacroTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Models
{
    public class MealCreate
    {
        [Required]
        [Display(Name = "Date")]
        public DateTime DateTime { get; set; }

        [Required]
        [Display(Name = "Meal Id")]
        public int MealId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string MealName { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string MealContent { get; set; }

        public List<FoodComponent> Food { get; set; }
    }
}
