using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pubtracker2Sql.Models
{
    public class ptRole
    {
        public string RoleId{ get; set; }
        public string RoleName{ get; set; }
        public Boolean Active{ get; set; }
    }
}