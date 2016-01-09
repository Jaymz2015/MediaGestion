using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaGestion.Modele.Dl.Dlo;
using MediaGestion.DAO;
using MediaGestion.Modele;
using MediaGestion.Modele.Dl.Dlo.Series;

namespace MediaGestion.Metier
{
    public class GestionnaireSeries : GestionnaireMedias
    {
        List<Serie> listeSeries = null;
        private SerieDAO LaSerieDAO = null;

        public GestionnaireSeries()
            : base()
        {
            try
            {
                LaSerieDAO = new SerieDAO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }


        /// <summary>
        /// Construction de la liste des series
        /// </summary>
        /// <returns></returns>
        public List<Serie> ObtenirSeries()
        {
            if (listeSeries == null)
            {
                listeSeries = LaSerieDAO.ObtenirListeSeries();
            }

            return listeSeries;
        }

        ///// <summary>
        ///// Retourne la serie dont l'id est passé en paramètre
        ///// </summary>
        ///// <param name="idSerie"></param>
        ///// <returns></returns>
        //public Serie ObtenirLaSerie(Guid idSerie)
        //{
        //    return LaSerieDAO.ObtenirSerie(idSerie);  
        //}

        /// <summary>
        /// Retourne le Serie dont l'id est passé en paramètre
        /// </summary>
        /// <param name="idSerie"></param>
        /// <returns></returns>
        public Serie ObtenirLaSerieComplete(Guid idSerie)
        {
        
            Serie serie = LaSerieDAO.ObtenirSerieComplete(idSerie);

            ////On associe la serie à chaque saison
            foreach (Saison saison in serie.ListeSaisons)
            {
                saison.LaSerie = serie;
            }

            //List<Exemplaire> listeExpl = LaSerieDAO.ObtenirListeExemplairesMedia(Serie.Code);
            //List<Exemplaire> listeSouhaits = LaSerieDAO.ObtenirListeSouhaitsMedia(Serie.Code);

            ////On associe le Serie à chaque exemplaire
            //foreach (Exemplaire expl in listeExpl) {
            //    expl.LeMedia = Serie;
            //}

            ////On associe le Serie à chaque exemplaire
            //foreach (Exemplaire expl in listeSouhaits)
            //{
            //    expl.LeMedia = Serie;
            //}

            //Serie.ListeExemplaire = listeExpl;
            //Serie.ListeSouhaits = listeSouhaits;


            return serie;        
        }

        /// <summary>
        /// CreerSerieEtExemplaire
        /// </summary>
        /// <param name="pSerie"></param>
        /// <param name="pCodeSupport"></param>
        /// <param name="pCodeProprietaire"></param>
        /// <returns></returns>
        public Serie CreerSerieEtExemplaire(Serie pSerie, string pCodeSupport, Guid pCodeProprietaire, DateTime pDateAcquisition, int pEtat)
        {
            return LaSerieDAO.CreerSerieEtExemplaire(pSerie, pCodeSupport, pCodeProprietaire, pDateAcquisition, pEtat);        
        }

        /// <summary>
        /// CreerSerieEtSouhait
        /// </summary>
        /// <param name="pSerie"></param>
        /// <param name="pCodeSupport"></param>
        /// <param name="pCodeProprietaire"></param>
        /// <returns></returns>
        public Serie CreerSerieEtSouhait(Serie pSerie, string pCodeSupport, Guid pCodeProprietaire)
        {

            return LaSerieDAO.CreerSerieEtSouhait(pSerie, pCodeSupport, pCodeProprietaire);
        }


        /// <summary>
        /// SupprimerSouhait
        /// </summary>
        /// <param name="pCodeSerie">pCodeSerie</param>
        /// <param name="pCodeProprietaire">pCodeProprietaire</param>
        /// <param name="pCodeSupport">pCodeSupport</param>
        public void SupprimerSouhait(Guid pCodeSerie, Guid pCodeProprietaire, String pCodeSupport)
        {
            LaSerieDAO.SupprimerSouhait(pCodeSerie, pCodeProprietaire, pCodeSupport);
        }


        /// <summary>
        /// Modification d'un Serie
        /// </summary>
        /// <param name="s">Serie à modifier</param>
        /// <returns></returns>
        public List<Media> MettreAJourSerie(Serie f)
        {
            LaSerieDAO.UpdateSerie(f);

            MediaDAO mediaDAO = new MediaDAO();

            return mediaDAO.ObtenirListeMedias(Constantes.EnumTypeMedia.SERIE);
        }

        /// <summary>
        /// AjouterSaison
        /// </summary>
        /// <param name="pCodeSerie"></param>
        /// <param name="pSaison"></param>
        /// <returns></returns>
        public bool AjouterSaison(Guid pCodeSerie, Saison pSaison)
        {
            pSaison.CodeSaison = Guid.NewGuid();
            return LaSerieDAO.AjouterSaison(pCodeSerie, pSaison);

        }
    }
}
