using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Sunrise.Models
{
    public class Apps_Countries
    {
        [Key]
        public  int Apps_CountriesId { get; set; }

        public string country_code { get; set; }

        public string country_name { get; set; }
    }
}
