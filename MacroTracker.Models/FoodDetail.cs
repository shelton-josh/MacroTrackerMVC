using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Models
{
    public class FoodDetail
    {
        [Display(Name = "Food Id")]
        public int FoodId { get; set; }

        [Display(Name = "Food Name")]
        public string FoodName { get; set; }

        public string Content { get; set; }

        public int Calories { get; set; }

        public int Proteins { get; set; }

        public int Fats { get; set; }

        public int Carbs { get; set; }
    }
}
