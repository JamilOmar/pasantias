using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Upgrade;
using NLog;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Comun
{
    public class Logger
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();

        public static void ExLogger(Exception ex)
        {
            logger.Error(ex.ToString());
        }

        public static void InfoLogger(string message)
        {
            logger.Info(message);
        }
    }
}
