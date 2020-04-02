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
using Installer_PM_Comms.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Installer_PM_Comms.Services;

namespace Installer_PM_Comms.Controllers
{
    public class JobsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMailService _mailService;

        public JobsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, IMailService mailService)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _mailService = mailService;
        }

        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            var jobs = _context.Jobs;
            return View(await jobs.ToListAsync());
            //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //if (User.IsInRole("Project_Manager"))
            //{
            //    var jobsToday = _context.Jobs;
            //    return View(await jobsToday.ToListAsync());
            //}
            //else if (User.IsInRole("Installer"))
            //{
            //    var jobsToday = _context.Job_Installs.Include( j => j.Job);
            //    return View(await jobsToday.ToListAsync());
            //}
            //else
            //{
            //    return View();
            //}
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .Include(j => j.Client)
                .Include(j => j.Project_Manager)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            var Installers = _context.Installers;
            var Clients = _context.Clients;
            var Job = new JobViewModel();
            Job.Clients = new List<Client>();
            Job.Installers = new List<Installer>();

            foreach(Client client in Clients)
            {
                Job.Clients.Add(client);
            }
            foreach(Installer installer in Installers)
            {
                Job.Installers.Add(installer);
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id");
            ViewData["ProjectManagerId"] = new SelectList(_context.Project_Managers, "Id", "Id");
            return View(Job);
        }
        public async Task<IActionResult> GetAllJobs()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var allJobs = _context.Job_Installs.Include(j => j.Job).Include(j => j.Job.Client);
            return View(await allJobs.ToListAsync());
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobViewModel JobViewModel, Installer installer)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var pmId = _context.Project_Managers.Where(p => p.IdentityUserId == userId).Select(p => p.Id).FirstOrDefault();
                string uniqueFileName = UploadedFile(JobViewModel);
                Job_Installs job_Installs = new Job_Installs();
                Job Job = new Job
                {
                    Blueprints = uniqueFileName,
                    JobNumber = JobViewModel.JobNumber,
                    JobName = JobViewModel.JobName,
                    Description = JobViewModel.Description,
                    InstallDate = JobViewModel.InstallDate,
                    ClientId = JobViewModel.ClientId,
                    ProjectManagerId = pmId
                };
                job_Installs.JobId = Job.Id;
                job_Installs.InstallerId = installer.Id;
                _context.Jobs.Add(Job);
                _context.Job_Installs.Add(job_Installs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(JobViewModel);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", job.ClientId);
            ViewData["ProjectManagerId"] = new SelectList(_context.Project_Managers, "Id", "Id", job.ProjectManagerId);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectManagerId,ClientId,JobName,JobNumber,Blueprints,Photos,Description,InstallDate,Notes,Completed,CompletionDate")] Job job)
        {
            if (id != job.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", job.ClientId);
            ViewData["ProjectManagerId"] = new SelectList(_context.Project_Managers, "Id", "Id", job.ProjectManagerId);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .Include(j => j.Client)
                .Include(j => j.Project_Manager)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobExists(int id)
        {
            return _context.Jobs.Any(e => e.Id == id);
        }

        private string UploadedFile(JobViewModel JobViewModel)
        {
            string uniqueFileName = null;
            if (JobViewModel.Blueprints != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + JobViewModel.Blueprints.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    JobViewModel.Blueprints.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
