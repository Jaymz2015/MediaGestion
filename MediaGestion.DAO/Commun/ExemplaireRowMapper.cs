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

                Media m = new Media();
                Proprietaire p = new Proprietaire();

                m.Code = pReader.GetGuid(pReader.GetOrdinal("codeMedia"));
                m.Titre = pReader.GetString(pReader.GetOrdinal("titre"));

                if (!pReader.IsDBNull(pReader.GetOrdinal("photo")))
                {
                    m.Photo = pReader.GetString(pReader.GetOrdinal("photo"));
                }
                
                m.TypeMedia = (MediaGestion.Modele.Constantes.EnumTypeMedia) pReader.GetByte(pReader.GetOrdinal("typeMedia"));
                m.LeGenre = new Genre(pReader.GetString(pReader.GetOrdinal("codeGenre")), pReader.GetString(pReader.GetOrdinal("libelleGenre")), (int)m.TypeMedia);

                ex.Code = pReader.GetGuid(pReader.GetOrdinal("codeExemplaire"));
               
                p.Code = pReader.GetGuid(pReader.GetOrdinal("codeProprietaire"));
                p.Nom = pReader.GetString(pReader.GetOrdinal("nom"));
                p.Prenom = pReader.GetString(pReader.GetOrdinal("prenom"));


                switch (m.TypeMedia)
                {
                    case Modele.Constantes.EnumTypeMedia.FILM:
                        ex.LeSupport = new Support(
                               pReader.GetString(pReader.GetOrdinal("codeSupport")),
                               pReader.GetString(pReader.GetOrdinal("libelleSupport")),
                               null);
                        break;
                    case Modele.Constantes.EnumTypeMedia.JEU:

                        Machine machine = new Machine();
                        machine.Code = pReader.GetString(pReader.GetOrdinal("codeMachine"));
                        machine.Nom = pReader.GetString(pReader.GetOrdinal("nomMachine"));

                        ex.LaMachine = machine;
                        
                        break;

                    default:
                        break;
                }


                ex.LeProprietaire = p;

                ex.LeMedia = m;

                string nomEmprunteur = String.Empty;

                //TODO : dangereux si le nombre de champs change !!
                if (pReader.FieldCount > 17)
                {
                    ex.Etat = new EtatMedia();

                    if (!pReader.IsDBNull(pReader.GetOrdinal("etat")))
                    {                      
                        ex.Etat.Code = pReader.GetByte(pReader.GetOrdinal("etat"));
                    }

                    if (!pReader.IsDBNull(pReader.GetOrdinal("libelleEtat")))
                    {
                        ex.Etat.Libelle = pReader.GetString(pReader.GetOrdinal("libelleEtat"));
                    }

                    if (!pReader.IsDBNull(pReader.GetOrdinal("nomEmprunteur")))
                    {
                        nomEmprunteur = pReader.GetString(pReader.GetOrdinal("nomEmprunteur"));
                    }

                    if (!pReader.IsDBNull(pReader.GetOrdinal("prenomEmprunteur")))
                    {
                        nomEmprunteur = nomEmprunteur + " " + pReader.GetString(pReader.GetOrdinal("prenomEmprunteur"));
                    }

                    ex.NomEmprunteur = nomEmprunteur;
                    
                    if (!pReader.IsDBNull(pReader.GetOrdinal("codeEmprunt")))
                    {
                         ex.CodeEmprunt = pReader.GetGuid(pReader.GetOrdinal("codeEmprunt"));
                    }
            
                    if (!pReader.IsDBNull(pReader.GetOrdinal("datePrete")))
                    {
                        ex.DateEmprunt = pReader.GetDateTime(pReader.GetOrdinal("datePrete"));
                    }

                    if (!pReader.IsDBNull(pReader.GetOrdinal("dateAcquisition")))
                    {
                        ex.DateAcquisition = pReader.GetDateTime(pReader.GetOrdinal("dateAcquisition"));
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
