using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MediaGestion.Modele.Dl.Dlo
{
    public class Media
    {
        public Guid Code { get; set; }



        public string Titre { get; set; }

        [DisplayName("Genre")]
        public Genre LeGenre { get; set; }

        [DisplayName("Date Sortie")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateSortie { get; set; }

        public string Jaquette { get; set; }
        public int Note { get; set; }

    }
}
