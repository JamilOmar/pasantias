using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Constants
{


    public  enum DBConnectionType
    {
        SAES, MOSS, PORTAFOLIO, BEMPLEO
    }
    public class DBConnection
    {

        public static string GetConnectionString(DBConnectionType con)
        {
            switch (con)
            {
                case DBConnectionType.SAES:
                    return ConnectorOne;
                case DBConnectionType.PORTAFOLIO:
                    return ConnectorTwo;
                case DBConnectionType.BEMPLEO:
                    return ConnectorThree;
            }
            return null;
        }
        public static   string ConnectorOne
        {
            get
            {
                return Properties.Connectors.Default.SAES;
            }
        }
        public static  string ConnectorTwo
        {
            get
            {
                return Properties.Connectors.Default.BEmpleo;
            }
        }
        public static  string ConnectorThree
        {
            get
            {
                return Properties.Connectors.Default.BEmpleo;
            }
        }
        public static  string ConnectorFour
        {
            get
            {
                return Properties.Connectors.Default.BEmpleo;
            }
        }
    }
}
