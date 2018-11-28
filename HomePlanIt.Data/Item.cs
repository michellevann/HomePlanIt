using System.ComponentModel.DataAnnotations;

namespace HomePlanIt.Data
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        public string ItemName { get; set; }

        public decimal Cost { get; set; }

        public bool IsBought { get; set; }

        public int DIYId { get; set; }

        public virtual DIY DIY { get; set; }
    }

}