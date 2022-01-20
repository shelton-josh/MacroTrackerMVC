using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Data
{
    public class Intake
    {
        [Key]
        public int IntakeId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        //[ForeignKey(nameof(Meal))]
        //public int MealId { get; set; }

        [Required]
        public string IntakeName { get; set; }

        [Required]
        public decimal FoodQty { get; set; }

        [ForeignKey(nameof(Food))]
        public virtual Food Food { get; set; }

        public string FoodDetail { get; set; }


        //public virtual Meal Meal{ get; set; }

    }
}
