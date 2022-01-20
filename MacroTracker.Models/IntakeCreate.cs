using MacroTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Models
{
    public class IntakeCreate
    {
        public string IntakeName { get; set; }
        public List <FoodComponent> Food { get; set; }
    }
}
