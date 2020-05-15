using System;
using System.ComponentModel.DataAnnotations;

namespace Pubtracker2FrontEnd.Models
{
    public class ptUser
    {
        public string UserId{ get; set; }
        public string LastName{ get; set; }
        public string FirstName{ get; set; }
        public Boolean Active{ get; set; }
    }
}