﻿using HomePlanIt.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePlanIt.Models
{
    public class FullProjectDetail
    {
        public int FullProjectId { get; set; }
        public int DIYId { get; set; }
        public int SupplyId { get; set; }
        public int RoadblockId { get; set; }

        public string ProjectName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Budgeted Amount")]
        public decimal BudgetedAmount { get; set; }

        [Display(Name = "Final Cost")]
        public decimal FinalCost { get; set; }

        public string Brand { get; set; }

        public string Color { get; set; }

        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Item")]
        public string SupplyName { get; set; }

        [Display(Name = "Total Cost")]
        public decimal TotalCost { get; set; }

        [Display(Name = "Roadblocker")]
        public string RoadblockName { get; set; }

        public string Plan { get; set; }
    }
}
