using System;

namespace MediaGestion.Modele.Dl.Dlo
{
    public class Constructeur
    {
        public Guid Code { get; set; }
        public string Nom { get; set; }
        public DateTime DateCreation { get; set; }
        public string Historique { get; set; }
        public byte[] Logo { get; set; }

        public Constructeur()
        {

        }


    }


}
