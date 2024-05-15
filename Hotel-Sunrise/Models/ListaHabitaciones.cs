using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Sunrise.Models
{
    public class ListaHabitaciones
    {
        public int ListaHabitacionesId { get; set; }
        public int reservacionesid { get; set; }

        public string Tipo { get; set; }

        public int Camas { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioxDia { get; set; }

        public DateTime FechaSalida { get; set; }

        public bool Disponible { get; set; }
    }
}
    

