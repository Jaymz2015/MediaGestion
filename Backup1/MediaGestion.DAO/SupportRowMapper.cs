using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;
using System.IO;

namespace MediaGestion.DAO
{
    public class SupportRowMapper : RowMapper<Support>
    {
        /// <summary>
        /// Construction d'un objet de type Support à partir d'une ligne de la table Support
        /// </summary>
        /// <param name="pReader"></param>
        /// <returns></returns>
        public override Support ExtraireDonneesReader(System.Data.SqlClient.SqlDataReader pReader)
        {
            byte[] icone = null;

            if (!pReader.IsDBNull(pReader.GetOrdinal("icone")))
            {
                //create a memory stream in which to write the raw data
                using (var ms = new MemoryStream())
                {
                    var buffer = new byte[1024];

                    //this call (with a null buffer paramater)
                    //will tell us the size of the data in the field
                    var dataSize = pReader.GetBytes(pReader.GetOrdinal("icone"), 0, null, 0, 0);
                    var dataRemaining = dataSize;

                    while (dataRemaining > 0)
                    {
                        var bytesToRead = (int)(buffer.Length < dataRemaining ? buffer.Length : dataRemaining);
                        //fill the buffer
                        pReader.GetBytes(pReader.GetOrdinal("icone"), dataSize - dataRemaining, buffer, 0, bytesToRead);
                        //write the buffer to the MemoryStream
                        ms.Write(buffer, 0, bytesToRead);
                        dataRemaining -= bytesToRead;
                    }

                    //Move the position of the MemoryStream
                    //Back to the beginning
                    ms.Seek(0, SeekOrigin.Begin);

                    icone = ms.ToArray();
                }
            }

            Support leSupport = new Support(
                pReader.GetString(pReader.GetOrdinal("code")),
                pReader.GetString(pReader.GetOrdinal("libelle")),
                icone);

            return leSupport; 
        }
    }
}
