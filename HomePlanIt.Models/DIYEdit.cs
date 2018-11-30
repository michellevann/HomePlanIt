using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePlanIt.Models
{
    public class DIYEdit
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal BudgetedAmount { get; set; }
        public decimal FinalCost { get; set; }
    }
}
