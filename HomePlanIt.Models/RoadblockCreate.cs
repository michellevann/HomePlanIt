﻿using HomePlanIt.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePlanIt.Models
{
    public class RoadblockCreate
    {
        [Required]
        [Display(Name = "Roadblocker")]
        public string RoadblockName { get; set; }

        public string Plan { get; set; }

        [Display(Name = "Completed?")]
        public bool IsComplete { get; set; }

        public override string ToString() => RoadblockName;
    }
}
