using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Installer_PM_Comms.Data;
using Installer_PM_Comms.Models;
using Microsoft.AspNetCore.Authorization;

namespace Installer_PM_Comms.Controllers
{
    [Authorize(Roles = "Project_Manager")]
    public class Project_ManagerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Project_ManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Project_Manager
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Project_Manager.Include(p => p.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Project_Manager/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project_Manager = await _context.Project_Manager
                .Include(p => p.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project_Manager == null)
            {
                return NotFound();
            }

            return View(project_Manager);
        }

        // GET: Project_Manager/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Project_Manager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdentityUserId,FirstName,LastName")] Project_Manager project_Manager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project_Manager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", project_Manager.IdentityUserId);
            return View(project_Manager);
        }

        // GET: Project_Manager/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project_Manager = await _context.Project_Manager.FindAsync(id);
            if (project_Manager == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", project_Manager.IdentityUserId);
            return View(project_Manager);
        }

        // POST: Project_Manager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdentityUserId,FirstName,LastName")] Project_Manager project_Manager)
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", project_Manager.IdentityUserId);
            return View(project_Manager);
        }

        // GET: Project_Manager/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project_Manager = await _context.Project_Manager
                .Include(p => p.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project_Manager == null)
            {
                return NotFound();
            }

            return View(project_Manager);
        }

        // POST: Project_Manager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project_Manager = await _context.Project_Manager.FindAsync(id);
            _context.Project_Manager.Remove(project_Manager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Project_ManagerExists(int id)
        {
            return _context.Project_Manager.Any(e => e.Id == id);
        }
    }
}
