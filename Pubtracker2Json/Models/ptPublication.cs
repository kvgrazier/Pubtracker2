using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pubtracker2Json.Models
{
    public class ptPublication
    {
        public string PublicationId;
        public string Title;
        public ptType Type;
        public string Series;
        public ptDivision Division;
        public ptRoles[] Roles;
        public ptStatus[] Statuses;
        public string Remarks;
    }
}