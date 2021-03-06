using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Models
{
    public class FoodComponent
    {
        [Display(Name = "Food Id")]
        public int FoodId { get; set; }

        [Display(Name = "Name")]
        public string FoodName { get; set; }

        [Display(Name = "Serving Size (oz)")]
        public decimal Serving { get; set; }

        public int Calories { get; set; }

        public decimal Proteins { get; set; }

        public decimal Fats { get; set; }

        public decimal Carbs { get; set; }
        public int Quantity { get; set; }
    }
}
