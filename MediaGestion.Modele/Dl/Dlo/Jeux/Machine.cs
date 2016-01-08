using System;

namespace MediaGestion.Modele.Dl.Dlo
{

    public class Machine
    {
        public string Code { get; set; }
        public LibAllocine.Constantes.EnumTypeMachine CodeJVC { get; set; }
        public string Nom { get; set; }
        public DateTime DateSortie { get; set; }
        public string Historique { get; set; }
        public string Caracteristiques { get; set; }
        public byte[] Logo { get; set; }
        public byte[] Photo { get; set; }
        public Constructeur LeConstructeur { get; set; }

        public Machine()
        {
            DateSortie = DateTime.Today;
        }

        public override string ToString()
        {

            return this.Code + " | " + this.Nom;
        }
		

    }

}
