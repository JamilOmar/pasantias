using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using db = BIT.UDLA.FLUJOS.PASANTIAS.DbConnector;
using queries = BIT.UDLA.FLUJOS.PASANTIAS.Constants;
using System.Collections.Specialized;
using BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance.Properties;
using BIT.UDLA.FLUJOS.PASANTIAS.Comun;
using System.Data;

namespace BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance
{
    public class PaisPersistance
    {

        public List<Pais> SeleccionarListaPaises()
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary itemListDictionary = new ListDictionary();


                    var query = obj.ExecuteQuery(Queries.Default.SeleccionarPaises, itemListDictionary).AsEnumerable();

                    List<Pais> result = new List<Pais>();
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
            return new List<Pais>();
        }
        public Pais MappeoOrigen(DataRow item)
        {
            Pais pais = new Pais();
            pais.Id = item.Field<int>("PAI_ID");
            pais.Nombre = item.Field<string>("PAI_NOMBRE");


            return pais;
        }
    }
}
