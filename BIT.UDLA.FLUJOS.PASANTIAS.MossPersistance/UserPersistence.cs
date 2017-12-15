using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties;
using BIT.UDLA.FLUJOS.PASANTIAS.Comun;

namespace BIT.UDLA.FLUJOS.PASANTIAS.MossPersistance
{
    public class UserPersistence
    {
        public static int GetUserID(string loginName,bool dominio, out string mensaje)
        {
            mensaje = "";
            try
            {
                SPUser user = null;
                if(dominio)
                    user = SPContext.Current.Web.EnsureUser(BIT.UDLA.FLUJOS.PASANTIAS.Comun.Properties.Parametros.Default.Dominio + loginName);
                else
                    user = SPContext.Current.Web.EnsureUser(loginName);
                return    user.ID;
            }
            catch (Exception ex)
            {
                mensaje = Mensajes.Default.ObtenerMOSSID;
                return -1;
            }
        }
    }
}
