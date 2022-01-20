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
               
        public int MealId { get; set; }
               
        public decimal FoodQty { get; set; }

        public int FoodId { get; set; }
        
        public string Food { get; set; }
    }
}
