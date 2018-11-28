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
        [Display(Name="Roadblocker")]
        public string RoadblockName { get; set; }

        [Display(Name="Completed?")]
        public bool IsComplete { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
