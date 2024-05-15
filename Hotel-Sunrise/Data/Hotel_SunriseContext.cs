using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hotel_Sunrise.Models;

namespace Hotel_Sunrise.Models
{
    public class Hotel_SunriseContext : DbContext
    {
        public Hotel_SunriseContext (DbContextOptions<Hotel_SunriseContext> options)
            : base(options)
        {
        }

        public DbSet<Hotel_Sunrise.Models.DetalleReservacion> DetalleReservacion { get; set; }

        public DbSet<Hotel_Sunrise.Models.Habitacion> Habitacion { get; set; }

        public DbSet<Hotel_Sunrise.Models.Pago> Pago { get; set; }

        public DbSet<Hotel_Sunrise.Models.Reservacion> Reservacion { get; set; }
        public DbSet<Hotel_Sunrise.Models.Tipo_Habitacion> Tipo_Habitacion { get; set; }
        public DbSet<Hotel_Sunrise.Models.Clientes> Clientes { get; set; }

        public DbSet<Hotel_Sunrise.Models.Usuario> Usuario { get; set; }

        public DbSet<Hotel_Sunrise.Models.Apps_Countries> Apps_Countries { get; set; }


        public DbSet<Hotel_Sunrise.Models.ListaHabitaciones> listaHabitaciones { get; set; }


    }
}
