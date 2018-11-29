using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePlanIt.Models
{
    public class DIYListItem
    {
        [Display(Name="Project Name")]
        public string ProjectName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name="Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime EndDate { get; set; }

        [Display(Name ="Budgeted Amount")]
        public decimal BudgetedAmount { get; set; }

        [Display(Name ="Final Cost")]
        public decimal FinalCost { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
