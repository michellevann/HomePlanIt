using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePlanIt.Models
{
    public class SupplyEdit
    {
        public int SupplyId { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public string SupplyName { get; set; }
        public decimal TotalCost { get; set; }
        public bool AlreadyHave { get; set; }
    }
}
