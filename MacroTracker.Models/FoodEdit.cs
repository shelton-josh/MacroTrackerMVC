using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Models
{
    public class FoodEdit
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string Content { get; set; }
        public int Calories { get; set; }
        public decimal Proteins { get; set; }
        public decimal Fats { get; set; }
        public decimal Carbs { get; set; }
    }
}
