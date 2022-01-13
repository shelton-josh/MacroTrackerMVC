﻿using MacroTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Models
{
    public class IntakeEdit
    {
        public int IntakeId { get; set; }

        public string IntakeName { get; set; }

        public virtual Food Food { get; set; }

        public decimal FoodQty { get; set; }

        public string FoodDetail { get; set; }
    }
}