using MacroTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Models
{
    public class IntakeDetail
    {
        [Display(Name = "Intake Id")]
        public int IntakeId { get; set; }

        [Display(Name = "Meal Id")]
        public int MealId { get; set; }

        public DateTime DateTime { get; set; }

        [Display(Name = "Food Quantity")]
        public decimal FoodQty { get; set; }
      
        public FoodListItem Food { get; set; }
    }
}