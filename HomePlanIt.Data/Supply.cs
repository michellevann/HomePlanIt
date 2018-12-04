using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomePlanIt.Data
{
    public class Supply
    {
        [Key]
        public int SupplyId { get; set; }

        //[Required]
        public Guid OwnerId { get; set; }

        //[Required]
        public int DIYId { get; set; }

        public string Brand { get; set; }

        public string Color { get; set; }

        public int Quantity { get; set; }

        //[Required]
        public string SupplyName { get; set; }

        public decimal TotalCost { get; set; }

        [DefaultValue(false)]
        public bool AlreadyHave { get; set; }
    }

}