using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaGestion.Modele.Dl.Dlo;
using Outils.CustomDataSource;

namespace MediaGestion.DAO
{
    public class GenreRowMapper : RowMapper<Genre>
    {
        /// <summary>
        /// Construction d'un objet de type Genre à partir d'une ligne de la table Genre
        /// </summary>
        /// <param name="pReader"></param>
        /// <returns></returns>
        public override Genre ExtraireDonneesReader(System.Data.SqlClient.SqlDataReader pReader)
        {
            Genre leGenre = new Genre(pReader.GetString(pReader.GetOrdinal("codeGenre")),pReader.GetString(pReader.GetOrdinal("libelle")));
			
            return leGenre; 
        }
    }
}
