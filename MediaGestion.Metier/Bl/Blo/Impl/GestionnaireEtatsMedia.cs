using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaGestion.Modele.Dl.Dlo;
using MediaGestion.DAO;

namespace MediaGestion.Metier.Bl.Blo.Impl
{
    public class GestionnaireEtatsMedia
    {
        /// <summary>
        /// Construction de la liste des Medias
        /// </summary>
        /// <returns></returns>
        public List<EtatMedia> ObtenirEtatsMedia()
        {
            EtatMediaDAO etatMediaDAO = new EtatMediaDAO();
            return etatMediaDAO.ObtenirListeEtats();
        }

    }
}
