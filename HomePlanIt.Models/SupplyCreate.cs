using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePlanIt.Models
{
    public class SupplyCreate
    {
        [Display(Name = "")]
        public bool AlreadyHave { get; set; }

        public string Brand { get; set; }

        public string Color { get; set; }

        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Item")]
        public string SupplyName { get; set; }

        public decimal TotalCost { get; set; }

        public override string ToString() => SupplyName;  
    }
}
