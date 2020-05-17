using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pubtracker2FrontEnd.Models
{
    public class PublicationViewModel
    {
        public ptPublication vmPublication { get; set; }
        public string SelectedDivisionId { get; set; }
        public IEnumerable<SelectListItem> slDivision { get; set; }
        public string SelectedRoleId { get; set; }
        public IEnumerable<SelectListItem> slRole { get; set; }
        public string SelectedStepId { get; set; }
        public IEnumerable<SelectListItem> slStep { get; set; }
        public string SelectedTypeId { get; set; }
        public IEnumerable<SelectListItem> slType { get; set; }
        public string SelectedUserId { get; set; }
        public IEnumerable<SelectListItem> slUser { get; set; }
        public string NowTime { get; set; }
    }
}