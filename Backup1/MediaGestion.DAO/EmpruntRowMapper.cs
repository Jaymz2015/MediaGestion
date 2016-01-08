using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;

namespace MediaGestion.DAO
{
    public class EmpruntRowMapper : RowMapper<Emprunt>
    {

        /// <summary>
        /// Construction d'un objet de type film à partir d'une ligne de la table Film
        /// </summary>
        /// <param name="pReader"></param>
        /// <returns></returns>
        public override Emprunt ExtraireDonneesReader(System.Data.SqlClient.SqlDataReader pReader)
        {
            Emprunt emp = new Emprunt();
            Proprietaire p = new Proprietaire();
            Film f = new Film();
            Exemplaire ex = new Exemplaire();

            f.Titre = pReader.GetString(pReader.GetOrdinal("titreFilm"));
            f.Code = pReader.GetGuid(pReader.GetOrdinal("codeFilm"));

            if (!pReader.IsDBNull(pReader.GetOrdinal("jaquette")))
            {
                f.Jaquette = pReader.GetString(pReader.GetOrdinal("jaquette"));
            }

            p.Code = pReader.GetGuid(pReader.GetOrdinal("codeProprio"));
            p.Nom = pReader.GetString(pReader.GetOrdinal("nom"));
            p.Prenom = pReader.GetString(pReader.GetOrdinal("prenom"));

            ex.LeSupport = new Support(
                pReader.GetString(pReader.GetOrdinal("codeSupport")),
                pReader.GetString(pReader.GetOrdinal("libelleSupport")),
                null);

            ex.LeProprietaire = p;

            ex.LeMedia = f;

            emp.Lemprunteur = new Emprunteur();
            
            if (!pReader.IsDBNull(pReader.GetOrdinal("nomEmprunteur")))
            {
                emp.Lemprunteur.Nom = pReader.GetString(pReader.GetOrdinal("nomEmprunteur"));
            }

            if (!pReader.IsDBNull(pReader.GetOrdinal("prenomEmprunteur")))
            {
                emp.Lemprunteur.Prenom = pReader.GetString(pReader.GetOrdinal("prenomEmprunteur"));
            }
   

            if (!pReader.IsDBNull(pReader.GetOrdinal("datePrete")))
            {
                emp.DatePrete = pReader.GetDateTime(pReader.GetOrdinal("datePrete"));
            }

            if (!pReader.IsDBNull(pReader.GetOrdinal("dateRendu")))
            {
                emp.DateRendu = pReader.GetDateTime(pReader.GetOrdinal("dateRendu"));
            }
            else
            {
                emp.DateRendu = DateTime.MinValue;
            }

    
            emp.Lexemplaire = ex;

            return emp;
        }
    }
}
