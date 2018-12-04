using HomePlanIt.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePlanIt.Models
{
    public class RoadblockListItem
    {
        public int RoadblockId { get; set; }

        [Display(Name="Roadblocker")]
        public string RoadblockName { get; set; }

        public string Plan { get; set; }

        [Display(Name="Completed?")]
        public bool IsComplete { get; set; }

        public int DIYId { get; set; }

        //public virtual DIY DIY { get; set; }

        public override string ToString() => RoadblockName;
    }
}
