using System;
using System.ComponentModel.DataAnnotations;

namespace Pubtracker2MVC.Models
{
    public class ptStep
    {
        public string StepId{ get; set; }
        public string StepName{ get; set; }
        public Boolean Active{ get; set; }
    }
}