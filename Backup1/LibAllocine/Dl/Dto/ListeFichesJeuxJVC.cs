using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibAllocine.Dl.Dto
{
    public class ListeFichesJeuxJVC : List<FicheJeuJVC>
    {
        

        public ListeFichesJeuxJVC()
        {

        }

        public void AjouterFicheJeuJVC(FicheJeuJVC ficheJeuJVC)
        {
            this.Add(ficheJeuJVC);
        }

        public FicheJeuJVC ObtenirFicheJeuJVC(int index)
        {
            return this.ElementAt<FicheJeuJVC>(index);
        }

        public int NbResultats()
        {
            return this.Count;
        }

        public void TrierListe()
        {
            this.Sort(ComparerJeux);
        }
        
        /// <summary>
        /// Fonction de comparaison de 2 fiches sur la date de sortie
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <returns></returns>
        private int ComparerJeux(FicheJeuJVC f1, FicheJeuJVC f2)
        {
            return f2.DateSortie.CompareTo(f1.DateSortie);
        }
 

    }
}
