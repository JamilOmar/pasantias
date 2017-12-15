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
    public class CarreraPersistance
    {
        public List<Carrera> SeleccionarListaCarrera()
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                  

                    var query = obj.ExecuteQuery(Queries.Default.SeleccionarCarreras, itemListDictionary).AsEnumerable();

                    List<Carrera> result = new List<Carrera>();
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
            return new List<Carrera>();
        }
        public Carrera MappeoOrigen(DataRow item)
        {
            Carrera carrera = new Carrera();
            carrera.ID = item.Field<int>("CAR_ID");
            carrera.Nombre = item.Field<string>("CAR_NOMBRE");


            return carrera;
        }
    }
}
