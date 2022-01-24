using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Models
{
    public class IntakeListItem
    {       
        public int IntakeId { get; set; }

        [Display(Name = "Meal Id")]
        public int MealId { get; set; }

        [Display(Name = "Food Id")]
        public int FoodId { get; set; }

        [Display(Name = "Food Quantity")]
        public decimal FoodQty { get; set; }
        
        public string Food { get; set; }
    }
}
