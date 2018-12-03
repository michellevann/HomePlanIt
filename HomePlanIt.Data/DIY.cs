using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePlanIt.Data
{
    public class DIY
    {
        [Key]
        public int DIYId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string ProjectName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal BudgetedAmount { get; set; }

        public decimal FinalCost { get; set; }

        [DefaultValue(false)]
        public bool IsFinished { get; set; }
    }
}
