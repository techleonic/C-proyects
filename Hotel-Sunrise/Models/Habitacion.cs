using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Hotel_Sunrise.Models;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Sunrise.Models
{
    public class Habitacion
    {
        [Key]
        public int HabitacionId { get; set; }
        public int No_Habitacion { get; set; }
        //M=Mantenimiento; R=Reservada;O=ocupada;D=Disponible
        public bool ocupada { get; set; }

        public int Tipo_Habitacionid { get; set; }
        public Tipo_Habitacion Tipo_Habitacion { get; set; }

    }

}
