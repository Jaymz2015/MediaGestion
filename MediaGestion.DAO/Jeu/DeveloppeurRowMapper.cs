using System.IO;
using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;
using System;

namespace MediaGestion.DAO
{
    public class EditeurRowMapper : RowMapper<Editeur>
    {
        /// <summary>
        /// Construction d'un objet de type Editeur à partir d'une ligne de la table Editeur
        /// </summary>
        /// <param name="pReader"></param>
        /// <returns></returns>
        public override Editeur ExtraireDonneesReader(System.Data.SqlClient.SqlDataReader pReader)
        {

            try
            {
                //byte[] icone = null;

                //if (!pReader.IsDBNull(pReader.GetOrdinal("logo")))
                //{
                //    //create a memory stream in which to write the raw data
                //    using (var ms = new MemoryStream())
                //    {
                //        var buffer = new byte[1024];

                //        //this call (with a null buffer paramater)
                //        //will tell us the size of the data in the field
                //        var dataSize = pReader.GetBytes(pReader.GetOrdinal("logo"), 0, null, 0, 0);
                //        var dataRemaining = dataSize;

                //        while (dataRemaining > 0)
                //        {
                //            var bytesToRead = (int)(buffer.Length < dataRemaining ? buffer.Length : dataRemaining);
                //            //fill the buffer
                //            pReader.GetBytes(pReader.GetOrdinal("logo"), dataSize - dataRemaining, buffer, 0, bytesToRead);
                //            //write the buffer to the MemoryStream
                //            ms.Write(buffer, 0, bytesToRead);
                //            dataRemaining -= bytesToRead;
                //        }

                //        //Move the position of the MemoryStream
                //        //Back to the beginning
                //        ms.Seek(0, SeekOrigin.Begin);

                //        icone = ms.ToArray();
                //    }
                //}

                Editeur editeur = new Editeur();

                editeur.Code = pReader.GetGuid(pReader.GetOrdinal("code"));
                editeur.Nom = pReader.GetString(pReader.GetOrdinal("nom"));
                //laEditeur.Logo = icone;

                return editeur;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la conversion de l'objet editeur : " + ex.Message);
            }
        }
    }
}
