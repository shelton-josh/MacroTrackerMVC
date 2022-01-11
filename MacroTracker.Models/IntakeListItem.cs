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
        [Display(Name = "Intake Id")]
        public int IntakeId { get; set; }

        [Display(Name = "Intake Name")]
        public string IntakeName { get; set; }
    }
}
