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
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AddressId,CompanyName,ContactName,ContactPhoneNumber,ContactEmailAddress")] Client client, Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Addresses.Add(address);
                client.Address.Id = address.Id;
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Job_Installs");
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", client.AddressId);
            return View(client);
        }
    }
}