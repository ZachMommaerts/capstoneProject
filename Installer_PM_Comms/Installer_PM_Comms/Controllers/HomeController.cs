using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Installer_PM_Comms.Models;
using Installer_PM_Comms.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Installer_PM_Comms.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDbContext, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = applicationDbContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var AdminInfo = _context.Admins.Where(c => c.IdentityUserId == userId).FirstOrDefault();
                if (AdminInfo == null)
                {
                    return RedirectToAction("Create", "Admins");
                }
                else
                {
                    return RedirectToAction("Index", "Admins");
                }
            }
            else if (User.IsInRole("Project_Manager"))
            {
                if (User.IsInRole("Project_Manager"))
                {
                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var DonorInfo = _context.Project_Managers.Where(c => c.IdentityUserId == userId).FirstOrDefault();
                    if (DonorInfo == null)
                    {
                        return RedirectToAction("Create", "Project_Manager");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Project_Manager");
                    }
                }
                else
                {
                    return View();
                }
            }
            else if (User.IsInRole("Installer"))
            {
                if (User.IsInRole("Installer"))
                {
                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var DonorInfo = _context.Installers.Where(c => c.IdentityUserId == userId).FirstOrDefault();
                    if (DonorInfo == null)
                    {
                        return RedirectToAction("Create", "Installers");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Installers");
                    }
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
