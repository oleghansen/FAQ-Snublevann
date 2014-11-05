using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace nettbutikkfaq.Models
{
    public class Question
    {
        [Display(Name = "Spørsmåls ID")]
        public int id { get; set; }
        [Display(Name = "Produktnavn")]
        [Required(ErrorMessage = "Produktnavn må oppgis")]
        public String title { get; set; }
        [Display(Name = "Beskrivelse")]
        [Required(ErrorMessage = "Beskrivelse må oppgis")]
        public String description { get; set; }
        [Display(Name = "Svar")]
        public String answer { get; set; }
        public String Category { get; set; }
        public int categoryid { get; set; }

    }
}