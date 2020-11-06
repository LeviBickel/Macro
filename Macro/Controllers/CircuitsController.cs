using Macro.Data;
using Macro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Macro.Controllers
{
    public class CircuitsController : Controller
    {
        private readonly MacroContext _context;
        private readonly IConfiguration _config;

        public CircuitsController(MacroContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        
        // GET: Macro
        public async Task<IActionResult> Index()
        {
            //Handles the authorization referencing the "Admin" group specified in the appsettings.json
            //if (ClaimsLoader.IsInGroup(User, _config.GetValue<string>("RO")) || ClaimsLoader.IsInGroup(User, _config.GetValue<string>("Modify")) || ClaimsLoader.IsInGroup(User, _config.GetValue<string>("Admin")))
            //{
                return View(await _context.Circuit.ToListAsync());
            //}
            //else
            //{
            //    return NotFound();
            //}
        }

        //Get: Macro/Disco
        public async Task<IActionResult> DiscoIndex()
        {
            //Handles the authorization referencing the "Admin" group specified in the appsettings.json
            //if (ClaimsLoader.IsInGroup(User, _config.GetValue<string>("Admin")))
            //{
                return View(await _context.DiscoCircuits.ToListAsync());
            //}
            //else
            //{
            //    return NotFound();
            //}
        }

        // GET: Macro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (ClaimsLoader.IsInGroup(User, _config.GetValue<string>("RO")) || ClaimsLoader.IsInGroup(User, _config.GetValue<string>("Modify")) || ClaimsLoader.IsInGroup(User, _config.GetValue<string>("Admin")))
            //{
                if (id == null)
                {
                    return NotFound();
                }

                var circuit = await _context.Circuit
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (circuit == null)
                {
                    return NotFound();
                }

                return View(circuit);
            //}
            //else { return NotFound(); }
        }

        // GET: Macro/Create
        public IActionResult Create()
        {
            //if (ClaimsLoader.IsInGroup(User, _config.GetValue<string>("Admin")))
            //{
                return View();
            //}
            //else
            //{
            //    return NotFound();
            //}
        }

        // POST: Macro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CCSD,Domain,CKT_Type,Source,SInt,SIP,Destination,DInt,DIP,CCO,Phone,Date,user")] Circuit circuit)
        {
            //if (ClaimsLoader.IsInGroup(User, _config.GetValue<string>("Admin")))
            //{
                if (ModelState.IsValid)
                {
                    Circuit newCircuit = new Circuit
                    {
                        ID = circuit.ID,
                        CCSD = circuit.CCSD,
                        Domain = circuit.Domain,
                        CKT_Type = circuit.CKT_Type,
                        Source = circuit.Source,
                        SInt = circuit.SInt,
                        SIP = circuit.SIP,
                        Destination = circuit.Destination,
                        DInt = circuit.DInt,
                        DIP = circuit.DIP,
                        CCO = circuit.CCO,
                        Phone = circuit.Phone,
                        Date = DateTime.UtcNow,
                        user = User.Identity.Name
                    };
                    _context.Add(newCircuit);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(circuit);
            //}
            //else { return NotFound(); }
        }

        // GET: Macro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //if (ClaimsLoader.IsInGroup(User, _config.GetValue<string>("Modify")) || ClaimsLoader.IsInGroup(User, _config.GetValue<string>("Admin")))
            //{
                if (id == null)
                {
                    return NotFound();
                }

                var circuit = await _context.Circuit.FindAsync(id);
                if (circuit == null)
                {
                    return NotFound();
                }
                return View(circuit);
            //}
            //else { return NotFound(); }
        }

        // POST: Macro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CCSD,Domain,CKT_Type,Source,SInt,SIP,Destination,DInt,DIP,CCO,Phone,Date,user")] Circuit circuit)
        {
            //if (ClaimsLoader.IsInGroup(User, _config.GetValue<string>("Modify")) || ClaimsLoader.IsInGroup(User, _config.GetValue<string>("Admin")))
            //{
                if (id != circuit.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        
                        Circuit newCircuit = new Circuit
                        {
                            ID = circuit.ID,
                            CCSD = circuit.CCSD,
                            Domain = circuit.Domain,
                            CKT_Type = circuit.CKT_Type,
                            Source = circuit.Source,
                            SInt = circuit.SInt,
                            SIP = circuit.SIP,
                            Destination = circuit.Destination,
                            DInt = circuit.DInt,
                            DIP = circuit.DIP,
                            CCO = circuit.CCO,
                            Phone = circuit.Phone,
                            Date = DateTime.UtcNow,
                            user = User.Identity.Name
                        };
                        
                        _context.Update(newCircuit);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CircuitExists(circuit.ID))
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
                return View(circuit);
            //}
            //else { return NotFound(); }
        }

        // GET: Macro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //if (ClaimsLoader.IsInGroup(User, _config.GetValue<string>("Admin")))
            //{
                if (id == null)
                {
                    return NotFound();
                }

                var circuit = await _context.Circuit
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (circuit == null)
                {
                    return NotFound();
                }

                return View(circuit);
            //}
            //else { return NotFound(); }
        }

        // POST: Macro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //if (ClaimsLoader.IsInGroup(User, _config.GetValue<string>("Admin")))
            //{
                //Add the addition of the disco table. Circuit will need to be added there before deleting. 
                var circuit = await _context.Circuit.FindAsync(id);

                DiscoCircuit newCircuit = new DiscoCircuit
                {
                    CCSD = circuit.CCSD,
                    Domain = circuit.Domain,
                    CKT_Type = circuit.CKT_Type,
                    Source = circuit.Source,
                    SInt = circuit.SInt,
                    SIP = circuit.SIP,
                    Destination = circuit.Destination,
                    DInt = circuit.DInt,
                    DIP = circuit.DIP,
                    CCO = circuit.CCO,
                    Phone = circuit.Phone,
                    Date = DateTime.UtcNow,
                    user = User.Identity.Name
                };
                _context.DiscoCircuits.Add(newCircuit);
                _context.Circuit.Remove(circuit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //else { return NotFound(); }
        }
        public async Task<IActionResult> Restore(int id)
        {
            //if(ClaimsLoader.IsInGroup(User, _config.GetValue<string>("Admin")))
            //{
                var Discocircuit = await _context.DiscoCircuits.FindAsync(id);

                var CCSDCheck = await _context.Circuit.FirstOrDefaultAsync(m=>m.CCSD == Discocircuit.CCSD);
                
                if(CCSDCheck == null)
                {
                    Circuit newCircuit = new Circuit
                    {
                        CCSD = Discocircuit.CCSD,
                        Domain = Discocircuit.Domain,
                        CKT_Type = Discocircuit.CKT_Type,
                        Source = Discocircuit.Source,
                        SInt = Discocircuit.SInt,
                        SIP = Discocircuit.SIP,
                        Destination = Discocircuit.Destination,
                        DInt = Discocircuit.DInt,
                        DIP = Discocircuit.DIP,
                        CCO = Discocircuit.CCO,
                        Phone = Discocircuit.Phone,
                        Date = DateTime.UtcNow,
                        user = User.Identity.Name
                    };
                    _context.Circuit.Add(newCircuit);
                    _context.DiscoCircuits.Remove(Discocircuit);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else { return RedirectToAction(nameof(DiscoIndex)); }
            //}
            //else { return NotFound(); }
        }
        private bool CircuitExists(int id)
        {
            return _context.Circuit.Any(e => e.ID == id);
        }
    }
}
