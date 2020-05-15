using System;
using System.ComponentModel.DataAnnotations;

namespace Pubtracker2FrontEnd.Models
{
    public class ptType
    {
        public string TypeId{ get; set; }
        public string TypeName{ get; set; }
        public Boolean Active{ get; set; }
    }
}