using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Outils.CustomDataSource
{
    public abstract class RowMapper<T>
    {

        public abstract T ExtraireDonneesReader(SqlDataReader pReader);

        /// <summary>
        /// IsNullOrMissing
        /// </summary>
        /// <param name="pReader">SqlDataReader</param>
        /// <param name="pNomColonne">string</param>
        /// <returns></returns>
        //protected bool IsNullOrMissing(SqlDataReader pReader, string pNomColonne) {

        //    bool resultat = true;

        //    try {
        //        resultat = pReader.IsDBNull(pReader.GetOrdinal(pNomColonne));
        //    } catch (IndexOutOfRangeException ex) {
        //        resultat = true;
        //    }

        //    return resultat;

        //}

    }
}
