using Macro.Data;
using Macro.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Macro.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly MacroContext _context;
        public AdministrationController(MacroContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            
            if (_context.AdminSettings.ToList().Count() != 0) 
            {
                AdminView AV = new AdminView
                {
                    settingsAdmin = _context.AdminSettings.First()
                };
                return View(AV);
            }
            else { return View(); }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(/*[Bind("ID,MaintenanceDate,Scheduled,MaintenanceTime")]*/ AdminView admin)
        {
            if (ModelState.IsValid)
            {
                if (_context.AdminSettings.ToList().Count() != 0)
                {
                    foreach (var item in _context.AdminSettings.ToList())
                    {
                        _context.Remove(_context.AdminSettings.Single(m => m.ID == item.ID));
                        await _context.SaveChangesAsync();
                    }

                }
                AdminSettings AS = new AdminSettings
                {
                    MaintenanceDate = admin.settingsAdmin.MaintenanceDate,
                    MaintenanceTime = admin.settingsAdmin.MaintenanceTime,
                    Scheduled = admin.settingsAdmin.Scheduled,
                };
                
                await _context.AddAsync(AS);
                await _context.SaveChangesAsync();

                AdminSettings.MaintenaceInfo = admin.settingsAdmin.MaintenanceDate;
                AdminSettings.ScheduledBool = admin.settingsAdmin.Scheduled;
                AdminSettings.MaintenaceTimeInfo = admin.settingsAdmin.MaintenanceTime;

                //Handle the other views here?

                return RedirectToAction("Index");
            }
            return View(admin);
        }

        public async Task<IActionResult> Clear()
        {
            if (_context.AdminSettings.ToList().Count() != 0)
            {
                foreach (var item in _context.AdminSettings.ToList())
                {
                    _context.Remove(_context.AdminSettings.Single(m => m.ID == item.ID));
                    await _context.SaveChangesAsync();
                }
                AdminSettings.MaintenaceInfo = null;
                AdminSettings.ScheduledBool = false;
            }
            return RedirectToAction("Index");
        }
    }
}
