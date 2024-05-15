using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Hotel_Sunrise.Models
{
    public class Clientes
    {
        [Key]
        public int ClientesId { get; set; }
        [Required]
        public string TipoIdentificacion { get; set; }
        [Required]
        public string Identificacion { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [NotMapped]
        public string NombreCompleto {get { return  Nombre+" "+Apellido ;} }
        [Display(Name ="País")]
        public string Pais { get; set; }
        public string Direccion { get; set; }
 //       [DisplayFormat()]
        public string Telefono { get; set; }


        public virtual ICollection<Reservacion> Reservaciones { get; set; }

    }
}
