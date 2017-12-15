using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Comun
{
    public static class Utils
    {
        public static string QuitarDominio(string user)
        {
            //return user.Replace(Parametros.Default.Dominio, "");
            return user.Substring(user.LastIndexOf('\\')+1);
        }

        public static string TrimText(string cntrl)
        {
            if (!String.IsNullOrEmpty(cntrl))
                return cntrl.Trim(' ', '\t','\n');
            else
                return cntrl;

        }
        public static string ObtenerUsernameAD(string cedula, out string mensaje)
        {
            mensaje = "";
            DirectoryEntry de = new DirectoryEntry(BIT.UDLA.FLUJOS.PASANTIAS.Comun.Properties.Parametros.Default.ADPath, BIT.UDLA.FLUJOS.PASANTIAS.Comun.Properties.Parametros.Default.ADUser, BIT.UDLA.FLUJOS.PASANTIAS.Comun.Properties.Parametros.Default.ADPassword);
            DirectorySearcher ds = new DirectorySearcher(de);
            ds.PropertiesToLoad.Add("samaccountname");
            ds.PropertiesToLoad.Add("cn");
            ds.Filter = string.Format(BIT.UDLA.FLUJOS.PASANTIAS.Comun.Properties.Parametros.Default.ADUserFilter, BIT.UDLA.FLUJOS.PASANTIAS.Comun.Properties.Parametros.Default.ADCedulaAttribute, cedula);
            ds.SearchScope = SearchScope.Subtree;

            try
            {
                SearchResult result = ds.FindOne();

                if (result != null)
                    return result.Properties["samaccountname"][0].ToString();
                else
                    mensaje = Mensajes.Default.ErrorADUsername;

            }
            catch (Exception ex)
            {
                mensaje = Mensajes.Default.Excepcion;
            }

            return "";
        }
    }
}
