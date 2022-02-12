using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Models
{
    public class AllUserViewModel
    {
        public IdentityUser User { get; set; }
        public SelectList Roles { get; set; }
    }
}