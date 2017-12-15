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
    public class CatalogoValorPersistance
    {
        public List<CatalogoValor> SeleccionarPorId(int id)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("VAL_TIPO", id);

                    List<DataRow> query = (from catalogo in obj.ExecuteQuery(Queries.Default.SeleccionarValores, itemListDictionary).AsEnumerable()
                                           select catalogo).ToList();

                    if (query != null)
                    {
                        return MappeoOrigen(query);
                    }
                }
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
            }
            return null;
        }

        public List<CatalogoValor> MappeoOrigen(List<DataRow> items)
        {
            List<CatalogoValor> listaCatalogosValor = new List<Entities.CatalogoValor>();

            foreach (var item in items)
            {
                listaCatalogosValor.Add(new CatalogoValor() { Id = item.Field<int>("VAL_ID"), IdTipo = item.Field<string>("VAL_VALOR"), Nombre = item.Field<string>("VAL_NOMBRE") });
            }

            return listaCatalogosValor;
        }

    }
}
