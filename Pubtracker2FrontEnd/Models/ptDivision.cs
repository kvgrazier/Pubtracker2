using System;
using System.ComponentModel.DataAnnotations;

namespace Pubtracker2FrontEnd.Models
{
    public class ptDivision
    {
        public string DivisionId { get; set; }
    public string DivisionName { get; set; }
        public Boolean Active { get; set; }
    }
}