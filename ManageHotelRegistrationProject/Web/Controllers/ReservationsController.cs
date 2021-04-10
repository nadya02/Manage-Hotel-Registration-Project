using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Web.Models;

namespace Web.Controllers
{
    [Authorize(Roles = "Administrator, Employees")]
    public class ReservationsController : Controller
    {
        private readonly HotelRegistrationDBContext _context;

        public ReservationsController()
        {
            _context = new HotelRegistrationDBContext();
        }

        // GET: Reservations

        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            var students = from s in _context.Reservation
                           select s;
            switch (sortOrder)
            {
                case "First Name":
                    students = students.OrderBy(s => s.User.FirstName);
                    break;
               /* case "Surname":
                    students = students.OrderBy(s => s.Surname);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.IsAdult);
                    break;*/
                default:
                    students = students.OrderBy(s => s.UserId);
                    break;
            }
            var hotelRegistrationDBContext = _context.Reservation.Include(r => r.Room);
            return View(await hotelRegistrationDBContext.ToListAsync());
        }

            // GET: Reservations/Details/5
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Id");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomId,UserId,DateOfArrival,DateOfLeaving,IsIncludedBreakfast,AllInclusive,FinalPrice,Id")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Id", reservation.RoomId);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Id", reservation.RoomId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomId,UserId,DateOfArrival,DateOfLeaving,IsIncludedBreakfast,AllInclusive,FinalPrice,Id")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
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
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Id", reservation.RoomId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservation.FindAsync(id);
            _context.Reservation.Remove(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /*public IActionResult MakeReservation2(ReservationModel model)
        {
            if (ModelState.IsValid == false) return View(model);
            if (model.roomNumber is null) return View(model);

            Room r = ds.getFirstEntry<Room>(r => r.number == model.roomNumber);

            if (r is null) return View(model);
            if (r.isFree == false) return View(model);

            r.isFree = false;
            ds.updateEntry(r);

            Client[] clients = new Client[model.clientsCnt];
            for (int i = 0; i < model.clientsCnt; i++)
            {
                clients[i] = new Client(model.clients[i]);
            }

            Reservation res = new Reservation()
            {
                user = ds.getFirstEntry<User>(u => u.id == HomeController.loggedUser.id),
                room = r,
                dateStart = model.dateStart,
                dateEnd = model.dateEnd,
                allInclusive = model.allInclusive,
                breakfast = model.breakfast,
            };
            res.cost = (model.dateEnd - model.dateStart).TotalDays * (clients.Count(c => c.isAdult == true) * r.priceAdult + clients.Count(c => c.isAdult == false) * r.priceChild
                       + ((res.breakfast == true) ? 1 : 0) + ((res.allInclusive == true) ? 3 : 0));

            int id = ds.addEntry(res);
            res = ds.getFirstEntry<Reservation>(r => r.id == id);

            foreach (Client c in clients)
            {
                if (res.clients == null) res.clients = new List<ReservationClientLinker>();

                Client dsClient = ds.getFirstEntry<Client>(x => x.firstName == c.firstName && x.lastName == c.lastName);
                if (dsClient == null)
                {
                    id = ds.addEntry(c);
                    dsClient = ds.getFirstEntry<Client>(x => x.id == id);
                }

                id = ds.addEntry(new ReservationClientLinker() { client = dsClient, reservation = res });
                ReservationClientLinker linker = ds.getFirstEntry<ReservationClientLinker>(l => l.id == id);
            }

            return Redirect("/Home/Dashboard");
        }*/

        private bool ReservationExists(int id)
        {
            return _context.Reservation.Any(e => e.Id == id);
        }
    }
}
