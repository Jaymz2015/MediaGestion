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

        public Constantes.EnumTypeMedia TypeMedia { get; set; }

        [DisplayName("Genre")]
        public Genre LeGenre { get; set; }

        [DisplayName("Date Sortie")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateSortie { get; set; }

        public string Photo { get; set; }
        public double Note { get; set; }
        public string UrlFiche { get; set; }

        public DateTime DateCreation { get; set; }
        public DateTime DateDerniereModification { get; set; }
        public int PEGI { get; set; }

        public List<Exemplaire> ListeExemplaire { get; set; }

        public List<Exemplaire> ListeSouhaits { get; set; }

        public override string ToString()
        {
            return Titre + "(" + TypeMedia.ToString() + ")";
        }

    }
}
