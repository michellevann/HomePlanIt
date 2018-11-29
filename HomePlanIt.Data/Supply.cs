using System.ComponentModel.DataAnnotations;

namespace HomePlanIt.Data
{
    public class Supply
    {
        [Key]
        public int SupplyId { get; set; }

        public string Brand { get; set; }

        public string Color { get; set; }

        public int Quantity { get; set; }

        [Required]
        public string SupplyName { get; set; }

        public decimal Cost { get; set; }
        
        public bool AlreadyHave { get; set; }

        public int DIYId { get; set; }

        public virtual DIY DIY { get; set; }
    }

}