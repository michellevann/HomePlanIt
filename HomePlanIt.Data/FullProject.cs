using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePlanIt.Data
{
    public class FullProject
    {
        [Key]
        public int FullProjectId { get; set; }
        public Guid OwnerId { get; set; }
        public int DIYId { get; set; }
        public int SupplyId { get; set; }
        public int RoadblockId { get; set; }

        public virtual DIY DIY { get; set; }
        public virtual Supply Supply { get; set; }
        public virtual Roadblock Roadblock { get; set; }
    }
}
