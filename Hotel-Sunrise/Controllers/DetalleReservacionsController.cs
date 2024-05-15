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
    public class DetalleReservacionsController : Controller
    {
        private readonly Hotel_SunriseContext _context;

        public DetalleReservacionsController(Hotel_SunriseContext context)
        {
            _context = context;
        }

        // GET: DetalleReservacions
        public async Task<IActionResult> Index()
        {
            var hotel_SunriseContext = _context.DetalleReservacion.Include(d => d.Reservacion);
            return View(await hotel_SunriseContext.ToListAsync());
        }

        // GET: DetalleReservacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleReservacion = await _context.DetalleReservacion
                .Include(d => d.Reservacion)
                .FirstOrDefaultAsync(m => m.DetalleReservacionId == id);
            if (detalleReservacion == null)
            {
                return NotFound();
            }

            return View(detalleReservacion);
        }

        // GET: DetalleReservacions/Create
        public IActionResult Create(int? idr,int? idc)
        {
            ViewBag.reservacion= _context.Reservacion.Find(idr);
            ViewBag.cliente = _context.Clientes.Find(idc);
            ViewBag.Habitaciones = _context.listaHabitaciones.Where(a => a.reservacionesid != idr).ToList() ;
            ViewBag.ListHabitaciones = _context.listaHabitaciones.Where(a => a.reservacionesid == idr).ToList();
            return View();
        }

        // POST: DetalleReservacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public  IActionResult add(int idre, int idcl,int hid)
        {
            
              DetalleReservacion detalleReservacion = new DetalleReservacion {
                    ReservacionId= idre,
                    Cantidad=0,
                };
            ListaHabitaciones habitacion = _context.listaHabitaciones.FirstOrDefault(a=>a.ListaHabitacionesId==hid);
            habitacion.Disponible = true;
            habitacion.reservacionesid = idre;
            _context.Update(habitacion);
            _context.Add(detalleReservacion);
            _context.SaveChangesAsync();
            return RedirectToAction("Create", new { idr = idre, idc= idcl });
        }

        // GET: DetalleReservacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleReservacion = await _context.DetalleReservacion.FindAsync(id);
            if (detalleReservacion == null)
            {
                return NotFound();
            }
            ViewData["ReservacionId"] = new SelectList(_context.Set<Reservacion>(), "ReservacionId", "Observaciones", detalleReservacion.ReservacionId);
            return View(detalleReservacion);
        }

        // POST: DetalleReservacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetalleReservacionId,ReservacionId,HabitacionId,Cantidad")] DetalleReservacion detalleReservacion)
        {
            if (id != detalleReservacion.DetalleReservacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleReservacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleReservacionExists(detalleReservacion.DetalleReservacionId))
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
            ViewData["ReservacionId"] = new SelectList(_context.Set<Reservacion>(), "ReservacionId", "Observaciones", detalleReservacion.ReservacionId);
            return View(detalleReservacion);
        }

        // GET: DetalleReservacions/Delete/5
        public IActionResult Delete(int idre,int idcl)
        {
            ViewBag.reservacion = _context.Reservacion.Find(idre);
            ViewBag.cliente = _context.Clientes.Find(idcl);
            ViewBag.lista = _context.listaHabitaciones.Where(a => a.reservacionesid == idre).ToList();
            ViewBag.cuenta = _context.listaHabitaciones.Where(a => a.reservacionesid == idre).Count();
            return View();
        }

        // POST: DetalleReservacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int idre, int idcl)
        {

           var Reservacion = _context.Reservacion.Include(a=>a.DetalleReservacions).FirstOrDefault(a => a.ReservacionId == idre);
            _context.Reservacion.Remove(Reservacion);
            return RedirectToAction("Create", "Reservacions", new { id = idcl });
        }

        private bool DetalleReservacionExists(int id)
        {
            return _context.DetalleReservacion.Any(e => e.DetalleReservacionId == id);
        }
    }
}
