using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Data
{
    public class Meal
    {
        [Key]
        public int MealId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string MealName { get; set; }

        [Required]
        public string MealContent { get; set; }
        
        public virtual List <Intake> Intake { get; set; }
    }
}
