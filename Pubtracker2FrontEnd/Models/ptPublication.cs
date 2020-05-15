﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Pubtracker2FrontEnd.Models
{
    public class ptPublication
    {
        public string PublicationId{ get; set; }
        public string Title{ get; set; }
        public ptType Type{ get; set; }
        public string Series{ get; set; }
        public ptDivision Division{ get; set; }
        public List<ptRoles>Roles{ get; set; }
        public List<ptStatus> Statuses{ get; set; }
        public string Remarks{ get; set; }
    }
}