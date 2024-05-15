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
    public class ReservacionsController : Controller
    {
        private readonly Hotel_SunriseContext _context;

        public ReservacionsController(Hotel_SunriseContext context)
        {
            _context = context;
        }

        // GET: Reservacions
        public async Task<IActionResult> Index()
        {
            var hotel_SunriseContext = _context.Reservacion.Include(r => r.Cliente);
            return View(await hotel_SunriseContext.ToListAsync());
        }

        // GET: Reservacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservacion = await _context.Reservacion
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.ReservacionId == id);
            if (reservacion == null)
            {
                return NotFound();
            }

            return View(reservacion);
        }

        // GET: Reservacions/Create
        public IActionResult Create(int? id)
        {
          ViewBag.cliente=  _context.Clientes.Include(a => a.Reservaciones).FirstOrDefault(a=>a.ClientesId==id);
            return View();
        }

        // POST: Reservacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id,[Bind("ReservacionId,Fecha_Ingreso,Fecha,Observaciones")] Reservacion reservacion)
        {
            if (ModelState.IsValid)
            {
                DateTime oldDate = reservacion.Fecha_Ingreso;
                DateTime newDate = reservacion.Fecha;
                TimeSpan ts = newDate - oldDate;
                int differenceInDays = ts.Days;
                reservacion.Dias = differenceInDays;
                reservacion.ClientesId = id;
                _context.Add(reservacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservacion);
        }

        // GET: Reservacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservacion = await _context.Reservacion.FindAsync(id);
            if (reservacion == null)
            {
                return NotFound();
            }
            ViewData["ClientesId"] = new SelectList(_context.Set<Clientes>(), "ClientesId", "Apellido", reservacion.ClientesId);
            return View(reservacion);
        }

        // POST: Reservacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservacionId,Fecha,ClientesId,Fecha_Ingreso,Dias,Observaciones,Estado")] Reservacion reservacion)
        {
            if (id != reservacion.ReservacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservacionExists(reservacion.ReservacionId))
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
            ViewData["ClientesId"] = new SelectList(_context.Set<Clientes>(), "ClientesId", "Apellido", reservacion.ClientesId);
            return View(reservacion);
        }

        // GET: Reservacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservacion = await _context.Reservacion
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.ReservacionId == id);
            if (reservacion == null)
            {
                return NotFound();
            }

            return View(reservacion);
        }

        // POST: Reservacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservacion = await _context.Reservacion.FindAsync(id);
            _context.Reservacion.Remove(reservacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CalDias([Bind("ReservacionId,Fecha,ClientesId,Fecha_Ingreso,Dias,Observaciones,Estado")] Reservacion reservacion)
        {
            DateTime fechai= reservacion.Fecha_Ingreso.Date;
            DateTime fechas = reservacion.Fecha.Date;
            TimeSpan ts = fechai - fechas;
            int dias = ts.Days;
            reservacion.Dias = dias;

            return View("Create", reservacion);
         
        }

        public IActionResult EditarCliente(int? Clienteid)
        {
            return RedirectToAction("Edit", "Clientes", new { id = Clienteid });
        }
        
        public IActionResult ListaClientes()
        {
            return RedirectToAction("Index", "Clientes");
        }
        private bool ReservacionExists(int id)
        {
            return _context.Reservacion.Any(e => e.ReservacionId == id);
        }
        public IActionResult addDetalle(int? idr, int? idc)
        {
            return RedirectToAction("Create", "DetalleReservacions", new { idr = idr, idc=idc });
        }

    }
}
