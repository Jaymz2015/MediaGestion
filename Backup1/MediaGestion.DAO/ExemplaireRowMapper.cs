using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;

namespace MediaGestion.DAO
{
    public class ExemplaireRowMapper : RowMapper<Exemplaire>
    {
        /// <summary>
        /// Construction d'un objet de type film à partir d'une ligne de la table Film
        /// </summary>
        /// <param name="pReader"></param>
        /// <returns></returns>
        public override Exemplaire ExtraireDonneesReader(System.Data.SqlClient.SqlDataReader pReader)
        {
            Exemplaire ex = null;

            try
            {
                ex = new Exemplaire();
                Proprietaire p = new Proprietaire();

                Film f = new Film();

                f.Titre = pReader.GetString(pReader.GetOrdinal("titreFilm"));
                f.Code = pReader.GetGuid(pReader.GetOrdinal("codeFilm"));

                if (!pReader.IsDBNull(pReader.GetOrdinal("jaquette")))
                {
                    f.Jaquette = pReader.GetString(pReader.GetOrdinal("jaquette"));
                }

                f.LeGenre = new Genre(pReader.GetString(pReader.GetOrdinal("codeGenre")), pReader.GetString(pReader.GetOrdinal("libelleGenre")));

                p.Code = pReader.GetGuid(pReader.GetOrdinal("codeProprio"));
                p.Nom = pReader.GetString(pReader.GetOrdinal("nom"));
                p.Prenom = pReader.GetString(pReader.GetOrdinal("prenom"));

                ex.LeSupport = new Support(
                    pReader.GetString(pReader.GetOrdinal("codeSupport")),
                    pReader.GetString(pReader.GetOrdinal("libelleSupport")),
                    null);

                ex.LeProprietaire = p;

                ex.LeMedia = f;


                string nomEmprunteur = String.Empty;

                //TODO : dangereux si le nombre de champs change !!
                if (pReader.FieldCount == 16)
                {

                    if (!pReader.IsDBNull(pReader.GetOrdinal("nomEmprunteur")))
                    {
                        nomEmprunteur = pReader.GetString(pReader.GetOrdinal("nomEmprunteur"));
                    }

                    if (!pReader.IsDBNull(pReader.GetOrdinal("prenomEmprunteur")))
                    {
                        nomEmprunteur = nomEmprunteur + " " + pReader.GetString(pReader.GetOrdinal("prenomEmprunteur"));
                    }

                    ex.NomEmprunteur = nomEmprunteur;


                    if (!pReader.IsDBNull(pReader.GetOrdinal("datePrete")))
                    {
                        ex.DateEmprunt = pReader.GetDateTime(pReader.GetOrdinal("datePrete"));
                    }

                    ex.EstDispo = pReader.GetInt32(pReader.GetOrdinal("dispo")) == 1 ? true : false;
                }

                try
                {
                    if (pReader.GetOrdinal("exemplaire_existant") > 0)
                    {
                        ex.EstSouhait = true;

                        if (!pReader.IsDBNull(pReader.GetOrdinal("exemplaire_existant")))
                        {
                            ex.ExemplaireExistant = pReader.GetString(pReader.GetOrdinal("exemplaire_existant"));
                        }

                    }
                }
                catch (IndexOutOfRangeException ie)
                {
                    //on ne fait rien, la colonne n'existe pas
                }

            }
            catch (Exception e)
            {
                throw e;
            }


            return ex;
        }
    }
}
