using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;

namespace MediaGestion.DAO
{
    public class EmpruntJeuRowMapper : RowMapper<Emprunt>
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
            Jeu j = new Jeu();
            Exemplaire ex = new Exemplaire();
            

            j.Titre = pReader.GetString(pReader.GetOrdinal("titre"));
            j.Code = pReader.GetGuid(pReader.GetOrdinal("code"));
            j.DateSortie = pReader.GetDateTime(pReader.GetOrdinal("dateSortie"));

            if (!pReader.IsDBNull(pReader.GetOrdinal("jaquette")))
            {
                j.Photo = pReader.GetString(pReader.GetOrdinal("jaquette"));
            }

            p.Code = pReader.GetGuid(pReader.GetOrdinal("codeProprio"));
            p.Nom = pReader.GetString(pReader.GetOrdinal("nom"));
            p.Prenom = pReader.GetString(pReader.GetOrdinal("prenom"));

            j.LeGenre.Code = pReader.GetString(pReader.GetOrdinal("codeGenre"));
            j.LeGenre.Libelle = pReader.GetString(pReader.GetOrdinal("libelleGenre"));
            j.LeGenre.Media = pReader.GetByte(pReader.GetOrdinal("media"));


            j.LaMachine.Code = pReader.GetString(pReader.GetOrdinal("codeMachine"));
            j.LaMachine.Nom = pReader.GetString(pReader.GetOrdinal("nomMachine"));

            if (!pReader.IsDBNull(pReader.GetOrdinal("codeEditeur")))
            {
                j.Editeur.Code = pReader.GetGuid(pReader.GetOrdinal("codeEditeur"));
                j.Editeur.Nom = pReader.GetString(pReader.GetOrdinal("nomEditeur"));
            }

            if (!pReader.IsDBNull(pReader.GetOrdinal("codeDeveloppeur")))
            {
                j.Developpeur.Code = pReader.GetGuid(pReader.GetOrdinal("codeDeveloppeur"));
                j.Developpeur.Nom = pReader.GetString(pReader.GetOrdinal("nomDeveloppeur"));
            }


            ex.LeProprietaire = p;
            ex.LeMedia = j;
            

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
