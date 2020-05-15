using System;
using System.ComponentModel.DataAnnotations;

namespace Pubtracker2FrontEnd.Models
{
    public class ptRole
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public Boolean Active { get; set; }
    }
}