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

    }
}
