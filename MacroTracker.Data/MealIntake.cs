using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Data
{
    public class MealIntake
    {
        [Key]
        public int MealIntakeId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(MealPlanId))]
        public virtual MealPlan MealPlan { get; set; }

        public int MealPlanId { get; set; }

        [ForeignKey(nameof(MealId))]
        public virtual Meal Meal { get; set; }

        public int MealId { get; set; }

        public int MealQty { get; set; }

        public virtual Food Food { get; set; }
    }
}
