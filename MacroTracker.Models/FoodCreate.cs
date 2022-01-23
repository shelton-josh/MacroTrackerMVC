using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Models
{
    public class FoodCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(40, ErrorMessage = "There are too many characters")]
        [Display(Name = "Food Name")]
        public string FoodName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        [Required]
        public int Calories { get; set; }

        [Required]
        public decimal Proteins { get; set; }

        [Required]
        public decimal Carbs { get; set; }

        [Required]
        public decimal Fats { get; set; }
    }
}
