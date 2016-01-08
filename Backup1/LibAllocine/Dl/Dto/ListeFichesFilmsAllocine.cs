using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace LibAllocine.Dl.Dto
{
    //12/03/2013 : prise en compte du format JSON, le format XML n'étant plus retourné
    //[XmlRoot(ElementName="feed", Namespace="http://www.allocine.net/v6/ns
    [XmlRoot(ElementName = "feed")]
    [Serializable]
    public class ListeFichesFilmsAllocine
    {
        [XmlElement("page")]
        public int NumPage { get; set; }

        [XmlElement("totalResults")]
        public int NbResultats { get; set; }

        [XmlElement("movie")]
        public FicheFilmAllocine[] LesFichesFilms;

        /// <summary>
        /// Retourne la liste des films
        /// </summary>
        /// <returns></returns>
        public List<FicheFilmAllocine> ObtenirListeFilms() {

            List<FicheFilmAllocine> liste = new List<FicheFilmAllocine>();

            if (LesFichesFilms != null)
            {
                liste = new List<FicheFilmAllocine>(LesFichesFilms);

                if (liste.Count > 1)
                {
                    liste.Sort(ComparerFilms);
                }
            }

            
            
            return liste;
        }


        /// <summary>
        /// Fonction de comparaison de 2 fiches sur la date de sortie
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <returns></returns>
        private int ComparerFilms(FicheFilmAllocine f1, FicheFilmAllocine f2) {

            return f2.AnneeProduction.CompareTo(f1.AnneeProduction);

        }
 

    }
}
