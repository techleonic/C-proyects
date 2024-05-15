using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Sunrise.Models
{
    public class Reservacion
    {
        [Key]
        public int ReservacionId { get; set; }

        public int IdHabitacion { get; set; }
        [Required]

        [Display(Name ="Fecha Salida")]
        public DateTime Fecha { get; set; }
        [Required]
        public int ClientesId { get; set; }
        [Required]
        public DateTime Fecha_Ingreso { get; set; }
        [Required]
        public int Dias { get; set; }
        public string Observaciones { get; set; }
        [Required]
        public Boolean Estado { get; set; }
        //para auditar
        [ScaffoldColumn(false)]
        public int UsuarioId { get; set; }
        [ScaffoldColumn(false)]
        public DateTime Modificado { get; set; }


        public virtual Clientes Cliente { get; set; }
        public virtual ICollection<DetalleReservacion> DetalleReservacions { get; set; } 


    }
}

