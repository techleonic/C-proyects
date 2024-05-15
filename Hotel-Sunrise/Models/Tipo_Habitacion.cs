using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Sunrise.Models
{
    public class Tipo_Habitacion
    {
        [Key]
        public int Tipo_Habitacionid { get; set; }

        public int DetalleReservacionId { get; set; }
        public DetalleReservacion detalleReservacion { get; set; }


        public int Camas { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        public decimal PrecioDia { get; set; }


        public List<Habitacion> Habitaciones { get; set; }
    }
}
