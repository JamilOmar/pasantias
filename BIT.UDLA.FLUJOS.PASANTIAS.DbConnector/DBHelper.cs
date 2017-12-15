using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIT.UDLA.FLUJOS.PASANTIAS.Constants;

namespace BIT.UDLA.FLUJOS.PASANTIAS.DbConnector
{
    public class DBMapper
    {
        public DbNetLink.Data.DataProvider Provider { get; set; }
        public string ConnectionString { get; set; }

    };

    public static class DBHelper
    {
        public static DBMapper GiveDatabaseType(DBConnectionType type)
        {
            switch (type)
            {
                case DBConnectionType.BEMPLEO:
                case DBConnectionType.PORTAFOLIO:
                    return new DBMapper { ConnectionString = DBConnection.GetConnectionString(type), Provider = DbNetLink.Data.DataProvider.SqlClient };
                case DBConnectionType.SAES:
                    return new DBMapper { ConnectionString = DBConnection.GetConnectionString(type), Provider = DbNetLink.Data.DataProvider.Odbc };
            }
            return null;

        }
    }
}
