using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pubtracker2Json.Models
{
    public class ptPublication
    {
        public string PublicationId{ get; set; }
        public int SortId { get; set; }
        public string Title{ get; set; }
        public ptType Type{ get; set; }
        public string Series{ get; set; }
        public ptDivision Division{ get; set; }
        public ptRoles[] Roles{ get; set; }
        public ptStatus[] Statuses{ get; set; }
        public string Remarks{ get; set; }
    }
}