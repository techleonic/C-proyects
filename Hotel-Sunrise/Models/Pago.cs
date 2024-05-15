using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using System.ComponentModel.DataAnnotations.Schema;


namespace Hotel_Sunrise.Models
    
{
    public class Pago
    {
        public int PagoId {get; set;}
        

        public string Estado_fact { get; set; }

        
        public string Tipo_Pago { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public int Descuento { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public int Subtotal { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public int IVA { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public int TotalPagar { get; set; }

        public int ReservacionId { get; set; }
        public Reservacion Reservacion { get; set; }
    }
}

