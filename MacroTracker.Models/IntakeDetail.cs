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
        public int IntakeId { get; set; }
             
        public int MealId { get; set; }

        public DateTime DateTime { get; set; }

        public decimal FoodQty { get; set; }
      
        public FoodListItem Food { get; set; }
    }
}