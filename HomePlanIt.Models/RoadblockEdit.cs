using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePlanIt.Models
{
    public class RoadblockEdit
    {
        public int RoadblockId { get; set; }        
        public string RoadblockName { get; set; }
        public bool IsComplete { get; set; }
        public string Plan { get; set; }
    }
}
