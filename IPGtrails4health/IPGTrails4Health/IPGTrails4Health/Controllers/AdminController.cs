using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPGTrails4Health.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IPGTrails4Health.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> userManager;

        public AdminController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public ViewResult Index() => View(userManager.Users);


    }
}