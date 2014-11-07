using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace nettbutikkfaq.Models
{
    public class Faq
    {
        [Display(Name = "Spørsmåls ID")]
        public int id { get; set; }

        [Display(Name = "Navn")]
        public String name { get; set; }

        [Display(Name = "E-postaddresse")]
        public String epost { get; set; }

        [Display(Name = "Produktnavn")]
        [Required(ErrorMessage = "Produktnavn må oppgis")]
        public String title { get; set; }
        [Display(Name = "Beskrivelse")]
        [Required(ErrorMessage = "Beskrivelse må oppgis")]
        public String question { get; set; }
        [Display(Name = "Svar")]
        public String answer { get; set; }
        public string category { get; set; }
        public int categoryid { get; set; }

    }
}