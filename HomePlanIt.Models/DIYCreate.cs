using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePlanIt.Models
{
    public class DIYCreate
    {
        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Budgeted Amount")]
        public decimal BudgetedAmount { get; set; }

        public decimal FinalCost { get; set; }

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

        //public override string ToString() => ProjectName;

        [Required]
        [Display(Name = "Roadblocker")]
        public string RoadblockName { get; set; }

        public string Plan { get; set; }

        [Display(Name = "Completed?")]
        public bool IsComplete { get; set; }

        //public override string ToString() => RoadblockName;
    }
}
