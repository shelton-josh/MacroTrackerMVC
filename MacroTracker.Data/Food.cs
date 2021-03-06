using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Data
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "There are too many characters (Max = 40)")]       
        public string FoodName { get; set; }

        [Required]
        public decimal Serving { get; set; }

        [Required]
        public int Calories { get; set; }

        [Required]
        public decimal Proteins { get; set; }

        [Required]
        public decimal Fats { get; set; }

        [Required]
        public decimal Carbs { get; set; }
    }
}
