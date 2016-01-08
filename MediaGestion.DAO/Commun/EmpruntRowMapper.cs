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
            Media m = new Film();
            Exemplaire ex = new Exemplaire();

            m.Titre = pReader.GetString(pReader.GetOrdinal("titre"));
            m.Code = pReader.GetGuid(pReader.GetOrdinal("codeMedia"));
            m.TypeMedia = (MediaGestion.Modele.Constantes.EnumTypeMedia)pReader.GetByte(pReader.GetOrdinal("typeMedia"));

            if (!pReader.IsDBNull(pReader.GetOrdinal("photo")))
            {
                m.Photo = pReader.GetString(pReader.GetOrdinal("photo"));
            }

            p.Code = pReader.GetGuid(pReader.GetOrdinal("codeProprietaire"));
            p.Nom = pReader.GetString(pReader.GetOrdinal("nom"));
            p.Prenom = pReader.GetString(pReader.GetOrdinal("prenom"));

            ex.LeSupport = new Support(
                pReader.GetString(pReader.GetOrdinal("codeSupport")),
                pReader.GetString(pReader.GetOrdinal("libelleSupport")),
                null);

            ex.LeProprietaire = p;

            ex.LeMedia = m;

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
