using Macro.Data;
using Macro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Macro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly MacroContext _context;
        public HomeController(ILogger<HomeController> logger, IConfiguration config, MacroContext context)
        {
            _logger = logger;
            _config = config;
            _context = context;
            
        }
        public IActionResult Index()
        {
            //Set the role for the user; This is accessed by the layout page to display role to the user.
            if (ClaimsLoader.IsInGroup(User, _config.GetValue<string>("Admin")))
            {
                ClaimsLoader.Role = "Administrator"; //THIS IS USED BY LAYOUT TO HANDLE WHICH LINKS APPEAR TO THE USER.
            }
            else if (ClaimsLoader.IsInGroup(User, _config.GetValue<string>("Modify")))
            {
                ClaimsLoader.Role = "Modify";
            }
            else
            {
                ClaimsLoader.Role = "";
            }

            List<Circuit> circuits = _context.Circuit.ToList();
            List<DiscoCircuit> discoCircuit = _context.DiscoCircuits.ToList();
            List<Software> soft = _context.Software.ToList();
            List<Circuit> last30 = new List<Circuit>();
            List<DiscoCircuit> last30Disco = new List<DiscoCircuit>();
            List<Software> last30Soft = new List<Software>();
            foreach (var item in circuits)
            {
                if((item.Date - DateTime.UtcNow).TotalDays > -30)
                {
                    last30.Add(item);
                }
            }
            foreach (var item in discoCircuit)
            {
                if ((item.Date - DateTime.UtcNow).TotalDays > -30)
                {
                    last30Disco.Add(item);
                }
            }
            foreach (var item in soft)
            {
                if ((item.added - DateTime.UtcNow).TotalDays > -30)
                {
                    last30Soft.Add(item);
                }
            }
            DashboardView newdash = new DashboardView
            {
                RecentCircuit = last30,
                RecentDisco = last30Disco,
                RecentSoft = last30Soft
        };


            return View(newdash); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
