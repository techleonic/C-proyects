using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel_Sunrise.Models;

namespace Hotel_Sunrise.Controllers
{
    public class Tipo_HabitacionController : Controller
    {
        private readonly Hotel_SunriseContext _context;

        public Tipo_HabitacionController(Hotel_SunriseContext context)
        {
            _context = context;
        }

        // GET: Tipo_Habitacion
        public async Task<IActionResult> Index()
        {
            var hotel_SunriseContext = _context.Tipo_Habitacion.Include(t => t.detalleReservacion);
            return View(await hotel_SunriseContext.ToListAsync());
        }

        // GET: Tipo_Habitacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_Habitacion = await _context.Tipo_Habitacion
                .Include(t => t.detalleReservacion)
                .FirstOrDefaultAsync(m => m.Tipo_Habitacionid == id);
            if (tipo_Habitacion == null)
            {
                return NotFound();
            }

            return View(tipo_Habitacion);
        }

        // GET: Tipo_Habitacion/Create
        public IActionResult Create()
        {
            ViewData["DetalleReservacionId"] = new SelectList(_context.DetalleReservacion, "DetalleReservacionId", "DetalleReservacionId");
            return View();
        }

        // POST: Tipo_Habitacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tipo_Habitacionid,DetalleReservacionId,Camas,PrecioDia")] Tipo_Habitacion tipo_Habitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipo_Habitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DetalleReservacionId"] = new SelectList(_context.DetalleReservacion, "DetalleReservacionId", "DetalleReservacionId", tipo_Habitacion.DetalleReservacionId);
            return View(tipo_Habitacion);
        }

        // GET: Tipo_Habitacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_Habitacion = await _context.Tipo_Habitacion.FindAsync(id);
            if (tipo_Habitacion == null)
            {
                return NotFound();
            }
            ViewData["DetalleReservacionId"] = new SelectList(_context.DetalleReservacion, "DetalleReservacionId", "DetalleReservacionId", tipo_Habitacion.DetalleReservacionId);
            return View(tipo_Habitacion);
        }

        // POST: Tipo_Habitacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tipo_Habitacionid,DetalleReservacionId,Camas,PrecioDia")] Tipo_Habitacion tipo_Habitacion)
        {
            if (id != tipo_Habitacion.Tipo_Habitacionid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipo_Habitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tipo_HabitacionExists(tipo_Habitacion.Tipo_Habitacionid))
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
            ViewData["DetalleReservacionId"] = new SelectList(_context.DetalleReservacion, "DetalleReservacionId", "DetalleReservacionId", tipo_Habitacion.DetalleReservacionId);
            return View(tipo_Habitacion);
        }

        // GET: Tipo_Habitacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_Habitacion = await _context.Tipo_Habitacion
                .Include(t => t.detalleReservacion)
                .FirstOrDefaultAsync(m => m.Tipo_Habitacionid == id);
            if (tipo_Habitacion == null)
            {
                return NotFound();
            }

            return View(tipo_Habitacion);
        }

        // POST: Tipo_Habitacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipo_Habitacion = await _context.Tipo_Habitacion.FindAsync(id);
            _context.Tipo_Habitacion.Remove(tipo_Habitacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tipo_HabitacionExists(int id)
        {
            return _context.Tipo_Habitacion.Any(e => e.Tipo_Habitacionid == id);
        }
    }
}
