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
using Microsoft.AspNetCore.Authorization;
using Installer_PM_Comms.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Installer_PM_Comms.Controllers
{
    public class Job_InstallsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public Job_InstallsController(ApplicationDbContext context, IWebHostEnvironment _webHostEnvironment)
        {
            _context = context;
            webHostEnvironment = _webHostEnvironment;
        }

        // GET: Job_Installs
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.IsInRole("Project_Manager"))
            {
                var jobsToday = _context.Job_Installs.Include(j => j.Job).Include(j => j.Job.Client);
                return View(await jobsToday.ToListAsync());
            }
            else if (User.IsInRole("Installer"))
            {
                var jobsToday = _context.Job_Installs.Include(j => j.Job).Include(j => j.Job.Client);
                return View(await jobsToday.ToListAsync());
            }
            else
            {
                return View();
            }
        }
        public async Task<IActionResult> GetAllJobs()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var allJobs = _context.Job_Installs.Include(j => j.Job).Include(j => j.Job.Client);
            return View(await allJobs.ToListAsync());
        }


        // GET: Job_Installs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
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
        [Authorize(Roles = "Project Manager, Admin")]
        // GET: Job_Installs/Create
        public IActionResult Create()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["InstallerId"] = new SelectList(_context.Installers, "Id", "Id");
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id");
            return View();
        }

        // POST: Job_Installs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobViewModel JobViewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                string uniqueFileName = UploadedFile(JobViewModel);
                Job Job = new Job
                {
                    Blueprints = uniqueFileName,
                    JobNumber = JobViewModel.JobNumber,
                    JobName = JobViewModel.JobName,
                };
                _context.Add(Job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(JobViewModel);
        }

        // GET: Job_Installs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
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
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
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
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
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
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var job_Installs = await _context.Job_Installs.FindAsync(id);
            _context.Job_Installs.Remove(job_Installs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Job_InstallsExists(int id)
        {
            return _context.Job_Installs.Any(e => e.JobId == id);
        }

        private string UploadedFile(JobViewModel JobViewModel)
        {
            string uniqueFileName = null;
            if (JobViewModel.Blueprints != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + JobViewModel.Blueprints.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    JobViewModel.Blueprints.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        public async Task<IActionResult> Directions(int? id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
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
    }
}
