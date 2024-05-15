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
    public class ListaHabitacionesController : Controller
    {
        private readonly Hotel_SunriseContext _context;

        public ListaHabitacionesController(Hotel_SunriseContext context)
        {
            _context = context;
        }

        // GET: ListaHabitaciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.listaHabitaciones.ToListAsync());
        }

        // GET: ListaHabitaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaHabitaciones = await _context.listaHabitaciones
                .FirstOrDefaultAsync(m => m.ListaHabitacionesId == id);
            if (listaHabitaciones == null)
            {
                return NotFound();
            }

            return View(listaHabitaciones);
        }

        // GET: ListaHabitaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ListaHabitaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ListaHabitacionesId,Tipo,Camas,PrecioxDia,FechaSalida")] ListaHabitaciones listaHabitaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listaHabitaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listaHabitaciones);
        }

        // GET: ListaHabitaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaHabitaciones = await _context.listaHabitaciones.FindAsync(id);
            if (listaHabitaciones == null)
            {
                return NotFound();
            }
            return View(listaHabitaciones);
        }

        // POST: ListaHabitaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ListaHabitacionesId,Tipo,Camas,PrecioxDia,FechaSalida")] ListaHabitaciones listaHabitaciones)
        {
            if (id != listaHabitaciones.ListaHabitacionesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listaHabitaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListaHabitacionesExists(listaHabitaciones.ListaHabitacionesId))
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
            return View(listaHabitaciones);
        }

        // GET: ListaHabitaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaHabitaciones = await _context.listaHabitaciones
                .FirstOrDefaultAsync(m => m.ListaHabitacionesId == id);
            if (listaHabitaciones == null)
            {
                return NotFound();
            }

            return View(listaHabitaciones);
        }

        // POST: ListaHabitaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listaHabitaciones = await _context.listaHabitaciones.FindAsync(id);
            _context.listaHabitaciones.Remove(listaHabitaciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListaHabitacionesExists(int id)
        {
            return _context.listaHabitaciones.Any(e => e.ListaHabitacionesId == id);
        }
    }
}
