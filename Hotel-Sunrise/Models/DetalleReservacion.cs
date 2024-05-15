using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Sunrise.Models
{
    public class DetalleReservacion
    {
        public int DetalleReservacionId { get; set; }
        [Required]
        public int ReservacionId { get; set; }
        [Required]
        public int Cantidad { get; set; }

        public int idHabitacion { get; set; }

        public virtual Reservacion Reservacion { get; set; }
        public List<Tipo_Habitacion> tipo_Habitaciones { get; set; }
    }
}
