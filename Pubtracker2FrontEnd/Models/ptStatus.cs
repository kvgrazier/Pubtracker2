using System;
using System.ComponentModel.DataAnnotations;

namespace Pubtracker2FrontEnd.Models
{
    public class ptStatus
    {
        public string StepId { get; set; }
        public string StepName{ get; set; }
        public DateTime StepDateTime{ get; set; }
    }
}