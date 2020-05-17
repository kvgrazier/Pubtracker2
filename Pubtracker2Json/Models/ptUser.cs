using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pubtracker2Json.Models
{
    public class ptUser
    {
        public string UserId{ get; set; }
        public string LastName{ get; set; }
        public string FirstName{ get; set; }
        public Boolean Active{ get; set; }
    }
}