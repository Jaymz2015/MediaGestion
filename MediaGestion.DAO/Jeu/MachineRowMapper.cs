using System.IO;
using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;
using System;

namespace MediaGestion.DAO
{
    public class MachineRowMapper : RowMapper<Machine>
    {
        /// <summary>
        /// Construction d'un objet de type Machine à partir d'une ligne de la table Machine
        /// </summary>
        /// <param name="pReader"></param>
        /// <returns></returns>
        public override Machine ExtraireDonneesReader(System.Data.SqlClient.SqlDataReader pReader)
        {

            try
            {
                Machine laMachine = new Machine();

                byte[] icone = null;

                if (!pReader.IsDBNull(pReader.GetOrdinal("logo")))
                {
                    //create a memory stream in which to write the raw data
                    using (var ms = new MemoryStream())
                    {
                        var buffer = new byte[1024];

                        //this call (with a null buffer paramater)
                        //will tell us the size of the data in the field
                        var dataSize = pReader.GetBytes(pReader.GetOrdinal("logo"), 0, null, 0, 0);
                        var dataRemaining = dataSize;

                        while (dataRemaining > 0)
                        {
                            var bytesToRead = (int)(buffer.Length < dataRemaining ? buffer.Length : dataRemaining);
                            //fill the buffer
                            pReader.GetBytes(pReader.GetOrdinal("logo"), dataSize - dataRemaining, buffer, 0, bytesToRead);
                            //write the buffer to the MemoryStream
                            ms.Write(buffer, 0, bytesToRead);
                            dataRemaining -= bytesToRead;
                        }

                        //Move the position of the MemoryStream
                        //Back to the beginning
                        ms.Seek(0, SeekOrigin.Begin);

                        icone = ms.ToArray();

                        laMachine.Logo = icone;
                    }
                }



                if (!pReader.IsDBNull(pReader.GetOrdinal("photo")))
                {
                    //create a memory stream in which to write the raw data
                    using (var ms = new MemoryStream())
                    {
                        var buffer = new byte[1024];

                        //this call (with a null buffer paramater)
                        //will tell us the size of the data in the field
                        var dataSize = pReader.GetBytes(pReader.GetOrdinal("photo"), 0, null, 0, 0);
                        var dataRemaining = dataSize;

                        while (dataRemaining > 0)
                        {
                            var bytesToRead = (int)(buffer.Length < dataRemaining ? buffer.Length : dataRemaining);
                            //fill the buffer
                            pReader.GetBytes(pReader.GetOrdinal("photo"), dataSize - dataRemaining, buffer, 0, bytesToRead);
                            //write the buffer to the MemoryStream
                            ms.Write(buffer, 0, bytesToRead);
                            dataRemaining -= bytesToRead;
                        }

                        //Move the position of the MemoryStream
                        //Back to the beginning
                        ms.Seek(0, SeekOrigin.Begin);

                        icone = ms.ToArray();

                        laMachine.Photo = icone;
                    }
                }

                laMachine.Code = pReader.GetString(pReader.GetOrdinal("code"));
                laMachine.Nom = pReader.GetString(pReader.GetOrdinal("nom"));
                
                laMachine.LeConstructeur = new Constructeur();

                if (!pReader.IsDBNull(pReader.GetOrdinal("codeConstructeur")))
                {
                    laMachine.LeConstructeur.Code = pReader.GetGuid(pReader.GetOrdinal("codeConstructeur"));
                }

                if (!pReader.IsDBNull(pReader.GetOrdinal("nomConstructeur")))
                {
                    laMachine.LeConstructeur.Nom = pReader.GetString(pReader.GetOrdinal("nomConstructeur"));
                }

                if (!pReader.IsDBNull(pReader.GetOrdinal("dateSortie")))
                {
                    laMachine.DateSortie = pReader.GetDateTime(pReader.GetOrdinal("dateSortie"));
                }

                if (!pReader.IsDBNull(pReader.GetOrdinal("historique")))
                {
                    laMachine.Historique = pReader.GetString(pReader.GetOrdinal("historique"));
                }

                if (!pReader.IsDBNull(pReader.GetOrdinal("caracteristiques")))
                {
                    laMachine.Caracteristiques = pReader.GetString(pReader.GetOrdinal("caracteristiques"));
                }

                return laMachine;
            }
            catch (Exception ex)
            {
                throw new Exception ("Erreur lors de la conversion de l'objet machine : " + ex.Message);
            }
        }
    }
}
