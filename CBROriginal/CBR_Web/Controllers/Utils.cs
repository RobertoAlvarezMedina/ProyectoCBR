using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CBR_Web.Utils
{
    public class Utils
    {
        public SqlParameterCollection parameterCollection { get; set; }

        public void LimpiarSqlParameterCollection()
        {
            parameterCollection.Clear();
        }
    }
}
