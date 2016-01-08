using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;
using System.Data.SqlClient;

namespace MediaGestion.DAO
{
    public class ExemplaireJeuRowMapper : RowMapper<Exemplaire>
    {
        /// <summary>
        /// Construction d'un objet de type jeu à partir d'une ligne de la table Jeu
        /// </summary>
        /// <param name="pReader"></param>
        /// <returns></returns>
        public override Exemplaire ExtraireDonneesReader(SqlDataReader pReader)
        {
            Exemplaire ex = null;

            try
            {
                ex = new Exemplaire();
                Proprietaire p = new Proprietaire();
                EtatMedia etatMedia = new EtatMedia();
                Jeu j = new Jeu();

                j.Titre = pReader.GetString(pReader.GetOrdinal("titre"));
                j.Code = pReader.GetGuid(pReader.GetOrdinal("code"));
                j.DateSortie = pReader.GetDateTime(pReader.GetOrdinal("dateSortie"));

                if (!pReader.IsDBNull(pReader.GetOrdinal("jaquette")))
                {
                    j.Photo = pReader.GetString(pReader.GetOrdinal("jaquette"));
                }

                j.LeGenre.Code = pReader.GetString(pReader.GetOrdinal("codeGenre"));
                j.LeGenre.Libelle = pReader.GetString(pReader.GetOrdinal("libelleGenre"));
                j.LeGenre.Media = pReader.GetByte(pReader.GetOrdinal("media"));

                p.Code = pReader.GetGuid(pReader.GetOrdinal("codeProprio"));
                p.Nom = pReader.GetString(pReader.GetOrdinal("nom"));
                p.Prenom = pReader.GetString(pReader.GetOrdinal("prenom"));

                
                ex.LeProprietaire = p;
                ex.LeMedia = j;

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

                if (!pReader.IsDBNull(pReader.GetOrdinal("synopsys")))
                {
                    j.Synopsys = pReader.GetString(pReader.GetOrdinal("synopsys"));
                }

                if (!pReader.IsDBNull(pReader.GetOrdinal("dateCreationFiche")))
                {
                    j.DateCreation = pReader.GetDateTime(pReader.GetOrdinal("dateCreationFiche"));
                }

                string nomEmprunteur = String.Empty;

                //TODO : dangereux si le nombre de champs change !!
                if (pReader.FieldCount > 25)
                {
                    if (!pReader.IsDBNull(pReader.GetOrdinal("dateAcquisition")))
                    {
                        ex.DateAcquisition = pReader.GetDateTime(pReader.GetOrdinal("dateAcquisition"));
                    }

                    if (!pReader.IsDBNull(pReader.GetOrdinal("dateEnregistrement")))
                    {
                        ex.DateEnregistrement = pReader.GetDateTime(pReader.GetOrdinal("dateEnregistrement"));
                    }

                    if (!pReader.IsDBNull(pReader.GetOrdinal("codeEtat")))
                    {
                        etatMedia.Code = pReader.GetByte(pReader.GetOrdinal("codeEtat"));
                    }

                    if (!pReader.IsDBNull(pReader.GetOrdinal("libelleEtat")))
                    {
                        etatMedia.Libelle = pReader.GetString(pReader.GetOrdinal("libelleEtat"));
                    }
                    ex.Etat = etatMedia;

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
                catch (IndexOutOfRangeException)
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
