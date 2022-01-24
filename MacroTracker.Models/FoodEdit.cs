using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Models
{
    public class FoodEdit
    {
        [Display(Name = "Food Id")]
        public int FoodId { get; set; }

        [Display(Name = "Food Name")]
        public string FoodName { get; set; }

        public decimal Serving { get; set; }

        public int Calories { get; set; }

        public decimal Proteins { get; set; }

        public decimal Fats { get; set; }

        public decimal Carbs { get; set; }
    }
}
