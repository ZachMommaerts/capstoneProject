using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Installer_PM_Comms.Data;
using Installer_PM_Comms.Models;

namespace Installer_PM_Comms.Controllers
{
    public class Project_ManagersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Project_ManagersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Job lists for the day
        public async Task<IActionResult> Index()
        {
            var jobsToday = _context.Jobs.Include(j => j.JobNumber).Include(j => j.JobName).Include(j => j.Client.CompanyName).Include(j => j.InstallDate);
            return View(await jobsToday.ToListAsync());
        }

        // GET: Project_Managers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project_Manager = await _context.Project_Managers
                .Include(p => p.Address)
                .Include(p => p.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project_Manager == null)
            {
                return NotFound();
            }

            return View(project_Manager);
        }

        // GET: Project_Managers/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id");
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Project_Managers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdentityUserId,AddressId,Name,ContactPhoneNumber,ContactEmailAddress")] Project_Manager project_Manager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project_Manager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", project_Manager.AddressId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", project_Manager.IdentityUserId);
            return View(project_Manager);
        }

        // GET: Project_Managers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project_Manager = await _context.Project_Managers.FindAsync(id);
            if (project_Manager == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", project_Manager.AddressId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", project_Manager.IdentityUserId);
            return View(project_Manager);
        }

        // POST: Project_Managers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdentityUserId,AddressId,Name,ContactPhoneNumber,ContactEmailAddress")] Project_Manager project_Manager)
        {
            if (id != project_Manager.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project_Manager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Project_ManagerExists(project_Manager.Id))
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
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", project_Manager.AddressId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", project_Manager.IdentityUserId);
            return View(project_Manager);
        }

        // GET: Project_Managers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project_Manager = await _context.Project_Managers
                .Include(p => p.Address)
                .Include(p => p.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project_Manager == null)
            {
                return NotFound();
            }

            return View(project_Manager);
        }

        // POST: Project_Managers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project_Manager = await _context.Project_Managers.FindAsync(id);
            _context.Project_Managers.Remove(project_Manager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Project_ManagerExists(int id)
        {
            return _context.Project_Managers.Any(e => e.Id == id);
        }
    }
}
