using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entities;
using Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    public class ClientsController : Controller
    {
        private readonly HotelRegistrationDBContext _context;

        public ClientsController()
        {
            _context = new HotelRegistrationDBContext();
        }

        // GET: Clients
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "First Name" : "";
            ViewData["DateSortParm"] = sortOrder == "Surname" ? "date_desc" : "Date";
            var students = from s in _context.Client
                           select s;
            switch (sortOrder)
            {
                case "First Name":
                    students = students.OrderByDescending(s => s.FirstName);
                    break;
                case "Surname":
                    students = students.OrderBy(s => s.FirstName);
                    break;
                default:
                    students = students.OrderBy(s => s.Surname);
                    break;
            }
            return View(await students.AsNoTracking().ToListAsync());
        }
        /* public async Task<IActionResult> Index(ClientIndex model)
         {
             int PageSize = 10;
             model.Pager ??= new PagerViewModel();
             model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;
             List<Client1> items = await _context.Client.Skip((model.Pager.CurrentPage - 1) * PageSize).Take(PageSize).Select(p => new Client1()
             {
                 Id =p.Id,
                 FirstName = p.FirstName,
                 Surname = p.Surname,
                 PhoneNumber = p.PhoneNumber,
                 Email = p.Email,
                 IsAdult = p.IsAdult,
                 Reservations = p.Reservations
             }).ToListAsync();
             model.Items = items;
             model.Pager.PagesCount = (int)Math.Ceiling(await _context.Client.CountAsync() / (double)PageSize);
             return View(model);
         }*/


        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,Surname,PhoneNumber,Email,IsAdult,Id")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,Surname,PhoneNumber,Email,IsAdult,Id")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
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
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Client.FindAsync(id);
            _context.Client.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Client.Any(e => e.Id == id);
        }
    }
}
