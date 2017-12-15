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
    public class OfertaLaboralPersistance
    {
        public OfertaLaboral SeleccionarPorId(int id)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("OFE_ID", id);

                    DataRow query = (from oferta in obj.ExecuteQuery(Queries.Default.ObtenerOfertasPorId, itemListDictionary).AsEnumerable()
                                     select oferta).FirstOrDefault();

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

        public OfertaLaboral MappeoOrigen(DataRow item)
        {
            OfertaLaboral oferta = new OfertaLaboral();

            oferta.OFE_ID = item.Field<int>("ofe_id");
            oferta.EMP_ID = item.Field<int?>("emp_id");
            oferta.Titulo = item.Field<string>("ofe_titulo");
            oferta.Modalidad = item.Field<string>("ofe_modalidad");
            oferta.Descripcion  = item.Field<string>("ofe_descripcion");
            oferta.Perfil = item.Field<string>("ofe_perfil");
            oferta.Empresa = item.Field<string>("ofe_empresa");
            oferta.Contacto = item.Field<string>("ofe_contacto");
            oferta.Email = item.Field<string>("ofe_email_contacto");
            oferta.Ciudad = item.Field<string>("ofe_ciudad_contacto");
            oferta.Telefono = item.Field<string>("ofe_telefono");
            oferta.Celular = item.Field<string>("ofe_celular");
            oferta.Fecha = item.Field<DateTime?>("ofe_fecha");
            oferta.FechaVencimiento = item.Field<DateTime?>("ofe_fecha_vencimiento");
            oferta.Salario = item.Field<int?>("ofe_salario");
            oferta.Confidencial = item.Field<int?>("ofe_confidencial");
            oferta.Estado = item.Field<int?>("ofe_estado");
            oferta.NombreCiudad = item.Field<string>("CIUDAD");
            oferta.NombreModalidad = item.Field<string>("MODALIDAD");
            oferta.NombreSalario = item.Field<string>("SALARIO");

            return oferta;


        }

        public List<OfertaLaboral> SeleccionarListaOfertas(int itemsPorPagina, int numeroPagina, out int maxItems)
        {
            maxItems = 0;
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                  
                    int numeroPag = numeroPagina * itemsPorPagina;
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("Offset", numeroPag);
                    itemListDictionary.Add("Limit", itemsPorPagina);
                    itemListDictionary.Add("MaxItems", maxItems);

                     DataTable query = obj.GetQuery(Queries.Default.ObtenerOfertarPaginado, Queries.Default.ObtenerOfertasPaginadoCount, itemListDictionary, out maxItems);


                    List<OfertaLaboral> result = new List<OfertaLaboral>();
                    foreach (DataRow item in query.Rows)
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
            return null;
        }

        public bool? EsOfertaValida(int oferID , int perID)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("OfeId", oferID);
                    itemListDictionary.Add("PerId", perID);
                    return obj.GetSingleQuery(Properties.Queries.Default.ValidarOfertaPorUsuario, itemListDictionary) as bool?;

                   
                }
            } 
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
            }
            return null;
        }

        public long? Insertar(int ofeID, int perID)
        {long? val=0;
            using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
            {
                ListDictionary itemListDictionary = new ListDictionary();
                itemListDictionary.Add("oferta_id", ofeID);
                itemListDictionary.Add("persona_id", perID);
                
                val = obj.insertQuery(Queries.Default.InsertarOferta, itemListDictionary);

            }
            return val;
        }
    }
}
