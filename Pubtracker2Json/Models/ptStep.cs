using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pubtracker2Json.Models
{
    public class ptStep
    {
        public string StepId{ get; set; }
        public string StepName{ get; set; }
        public Boolean Active{ get; set; }
    }
}