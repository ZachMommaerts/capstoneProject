﻿using System;
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
    public class InstallersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstallersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Installers
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var applicationDbContext = _context.Installers.Include(i => i.Address).Include(i => i.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Installers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var installer = await _context.Installers
                .Include(i => i.Address)
                .Include(i => i.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (installer == null)
            {
                return NotFound();
            }

            return View(installer);
        }

        // GET: Installers/Create
        public IActionResult Create()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Address address = new Address();
            int AddressId = (address.Id = 5);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return RedirectToAction("Index", "Jobs");
        }

        // POST: Installers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdentityUserId,AddressId,Name,ContactPhoneNumber,ContactEmailAddress")] Installer installer)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Address address = new Address();
            {
                address.StreetName = "3880 w milwaukee rd";
                address.City = "Milwaukee";
                address.State = "Wisconsin";
                address.ZipCode = 53208;
            }
            installer.AddressId = address.Id;
            if (ModelState.IsValid)
            {
                _context.Addresses.Add(address);
                _context.Installers.Add(installer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", installer.AddressId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", installer.IdentityUserId);
            return View(installer);
        }

        // GET: Installers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var installer = await _context.Installers.FindAsync(id);
            if (installer == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", installer.AddressId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", installer.IdentityUserId);
            return View(installer);
        }

        // POST: Installers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdentityUserId,AddressId,Name,ContactPhoneNumber,ContactEmailAddress")] Installer installer)
        {
            if (id != installer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(installer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstallerExists(installer.Id))
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
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", installer.AddressId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", installer.IdentityUserId);
            return View(installer);
        }

        // GET: Installers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var installer = await _context.Installers
                .Include(i => i.Address)
                .Include(i => i.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (installer == null)
            {
                return NotFound();
            }

            return View(installer);
        }

        // POST: Installers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var installer = await _context.Installers.FindAsync(id);
            _context.Installers.Remove(installer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstallerExists(int id)
        {
            return _context.Installers.Any(e => e.Id == id);
        }
    }
}
