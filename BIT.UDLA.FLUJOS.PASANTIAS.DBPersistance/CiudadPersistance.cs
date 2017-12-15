using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using db = BIT.UDLA.FLUJOS.PASANTIAS.DbConnector;
using queries = BIT.UDLA.FLUJOS.PASANTIAS.Constants;
using System.Collections.Specialized;
using BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance.Properties;
using BIT.UDLA.FLUJOS.PASANTIAS.Comun;
using System.Data;
namespace BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance
{
    public class CiudadPersistance
    {
        public List<Ciudad> SeleccionarListaCiudades()
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                  

                    var query = obj.ExecuteQuery(Queries.Default.SeleccionarCiudades, itemListDictionary).AsEnumerable();

                    List<Ciudad> result = new List<Ciudad>();
                    foreach (var item in query)
                    {
                        result.Add(MappeoOrigen(item));
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.ExLogger(ex);
            }
            return new List<Ciudad>();
        }
        public Ciudad MappeoOrigen(DataRow item)
        {
            Ciudad ciudad = new Ciudad();
            ciudad.ID = item.Field<int>("CIU_ID");
            ciudad.Nombre = item.Field<string>("CIU_NOMBRE");


            return ciudad;
        }
    }
}
