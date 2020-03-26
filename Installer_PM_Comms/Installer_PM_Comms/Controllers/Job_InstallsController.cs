using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Installer_PM_Comms.Data;
using Installer_PM_Comms.Models;
using System.Security.Claims;

namespace Installer_PM_Comms.Controllers
{
    public class Job_InstallsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Job_InstallsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Job_Installs
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.IsInRole("Project_Manager"))
            {
                var jobsToday = _context.Job_Installs.Where(j => j.Job.Project_Manager.IdentityUserId == userId).Where(j => j.Job.InstallDate == DateTime.Today).Include(j => j.Job.JobNumber).Include(j => j.Job.JobName).Include(j => j.Job.Client.CompanyName);
                return View(await jobsToday.ToListAsync());
            }
            else if (User.IsInRole("Installer"))
            {
                var jobsToday = _context.Job_Installs.Where(j => j.Installer.IdentityUserId == userId).Where(j => j.Job.InstallDate == DateTime.Today).Include(j => j.Job.JobNumber).Include(j => j.Job.JobName).Include(j => j.Job.Client.CompanyName);
                return View(await jobsToday.ToListAsync());
            }
            else
            {
                return View();
            }
        }

        // GET: Job_Installs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job_Installs = await _context.Job_Installs
                .Include(j => j.Installer)
                .Include(j => j.Job)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (job_Installs == null)
            {
                return NotFound();
            }

            return View(job_Installs);
        }

        // GET: Job_Installs/Create
        public IActionResult Create()
        {
            ViewData["InstallerId"] = new SelectList(_context.Installers, "Id", "Id");
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id");
            return View();
        }

        // POST: Job_Installs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InstallerId,JobId")] Job_Installs job_Installs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(job_Installs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstallerId"] = new SelectList(_context.Installers, "Id", "Id", job_Installs.InstallerId);
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id", job_Installs.JobId);
            return View(job_Installs);
        }

        // GET: Job_Installs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job_Installs = await _context.Job_Installs.FindAsync(id);
            if (job_Installs == null)
            {
                return NotFound();
            }
            ViewData["InstallerId"] = new SelectList(_context.Installers, "Id", "Id", job_Installs.InstallerId);
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id", job_Installs.JobId);
            return View(job_Installs);
        }

        // POST: Job_Installs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InstallerId,JobId")] Job_Installs job_Installs)
        {
            if (id != job_Installs.JobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job_Installs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Job_InstallsExists(job_Installs.JobId))
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
            ViewData["InstallerId"] = new SelectList(_context.Installers, "Id", "Id", job_Installs.InstallerId);
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id", job_Installs.JobId);
            return View(job_Installs);
        }

        // GET: Job_Installs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job_Installs = await _context.Job_Installs
                .Include(j => j.Installer)
                .Include(j => j.Job)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (job_Installs == null)
            {
                return NotFound();
            }

            return View(job_Installs);
        }

        // POST: Job_Installs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job_Installs = await _context.Job_Installs.FindAsync(id);
            _context.Job_Installs.Remove(job_Installs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Job_InstallsExists(int id)
        {
            return _context.Job_Installs.Any(e => e.JobId == id);
        }
    }
}
