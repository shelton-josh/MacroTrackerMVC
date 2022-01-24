using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Data
{
    public class MealPlan
    {
        [Key]
        public int MealPlanId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string MealPlanName { get; set; }

        [Required]
        public string MealPlanContent { get; set; }

        public virtual List<MealIntake> MealIntake { get; set; }

        public int Calories { get; set; }

        public decimal Proteins { get; set; }

        public decimal Fats { get; set; }

        public decimal Carbs { get; set; }
    }
}
