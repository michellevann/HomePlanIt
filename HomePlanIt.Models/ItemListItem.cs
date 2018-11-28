using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePlanIt.Models
{
    public class ItemListItem
    {
        [Display(Name="Item Needed")]
        public string ItemName { get; set; }

        [Display(Name="Purchased?")]
        public bool IsBought { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
