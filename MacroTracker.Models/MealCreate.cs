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
        public DateTime DateTime { get; set; }

        [Required]
        public int MealId { get; set; }

        [Required]
        public string MealName { get; set; }

        [Required]
        public string MealContent { get; set; }

        public List<FoodComponent> Food { get; set; }
    }
}
