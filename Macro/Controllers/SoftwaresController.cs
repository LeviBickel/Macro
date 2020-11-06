using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Macro.Data;
using Macro.Models;

namespace Macro.Controllers
{
    public class SoftwaresController : Controller
    {
        private readonly MacroContext _context;

        public SoftwaresController(MacroContext context)
        {
            _context = context;
        }

        // GET: Softwares
        public async Task<IActionResult> Index()
        {
            return View(await _context.Software.ToListAsync());
        }

        // GET: Softwares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var software = await _context.Software
                .FirstOrDefaultAsync(m => m.ID == id);
            if (software == null)
            {
                return NotFound();
            }

            return View(software);
        }

        // GET: Softwares/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Softwares/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Manufacturer,SoftwareTitle,AssignedTo,PurchaseOrder,LicenseType,PurchaseDate,Supported,SupportExp,TotalKeys,UsedKeys,LicenseKey,added")] Software software)
        {
            if (ModelState.IsValid)
            {
                software.added = DateTime.UtcNow;
                _context.Add(software);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(software);
        }

        // GET: Softwares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var software = await _context.Software.FindAsync(id);
            if (software == null)
            {
                return NotFound();
            }
            return View(software);
        }

        // POST: Softwares/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Manufacturer,SoftwareTitle,AssignedTo,PurchaseOrder,LicenseType,PurchaseDate,Supported,SupportExp,TotalKeys,UsedKeys,LicenseKey,added")] Software software)
        {
            if (id != software.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    software.added = DateTime.UtcNow;
                    _context.Update(software);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoftwareExists(software.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(software);
        }

        // GET: Softwares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var software = await _context.Software
                .FirstOrDefaultAsync(m => m.ID == id);
            if (software == null)
            {
                return NotFound();
            }

            return View(software);
        }

        // POST: Softwares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var software = await _context.Software.FindAsync(id);
            _context.Software.Remove(software);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoftwareExists(int id)
        {
            return _context.Software.Any(e => e.ID == id);
        }
    }
}
