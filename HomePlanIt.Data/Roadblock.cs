using System.ComponentModel.DataAnnotations;

namespace HomePlanIt.Data
{
    public class Roadblock
    {
        [Key]
        public int RoadblockId { get; set; }

        [Required]
        public string RoadblockName { get; set; }

        public bool IsComplete { get; set; }

        public string Plan { get; set; }

        public int DIYId { get; set; }

        public virtual DIY DIY { get; set; }
    }
}