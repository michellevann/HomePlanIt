using HomePlanIt.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePlanIt.Models
{
    public class RoadblockDetail
    {
        [Key]
        public int RoadblockId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        //[Required]
        public int DIYId { get; set; }

        [Required]
        public string RoadblockName { get; set; }

        [DefaultValue(false)]
        public bool IsComplete { get; set; }

        public string Plan { get; set; }

        //public virtual DIY DIY { get; set; }

        public override string ToString() => $"[{RoadblockId}]{RoadblockName}";
    }
}
