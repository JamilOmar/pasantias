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
    public class EmpresaPersistance
    {
        public bool Insertar(Empresa item, out long? idEmpresa)
        {
            using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
            {
                ListDictionary itemListDictionary = new ListDictionary();
                itemListDictionary.Add("emp_ruc", item.Ruc);
                itemListDictionary.Add("emp_razon_social", item.RazonSocial);
                itemListDictionary.Add("emp_nombre", item.NombreComercial);
                itemListDictionary.Add("emp_representante", item.RepresentanteLegal);
                itemListDictionary.Add("emp_direccion", item.Direccion);
                itemListDictionary.Add("emp_telefono", item.Telefono);

                idEmpresa = obj.insertQuery(Queries.Default.InsertarEmpresa, itemListDictionary);
                return idEmpresa <= 0;
            }
        }

      

        public bool Eliminar(Empresa item)
        {
            using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
            {
                ListDictionary itemListDictionary = new ListDictionary();
                itemListDictionary.Add("emp_id", item.Id);

                var result = obj.deleteQuery(Queries.Default.EliminarEmpresa, itemListDictionary);
                return result <= 0;
            }
        }

        public Empresa Seleccionar(Empresa item)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("emp_id", item.Id);

                    DataRow query = (from empresa in obj.ExecuteQuery(Queries.Default.SeleccionarEmpresa, itemListDictionary).AsEnumerable()
                                     select empresa).FirstOrDefault();

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

        public Empresa SeleccionarPorId(int id)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("emp_id", id);

                    DataRow query = (from empresa in obj.ExecuteQuery(Queries.Default.SeleccionarEmpresa, itemListDictionary).AsEnumerable()
                                     select empresa).FirstOrDefault();

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

        public Empresa MappeoOrigen(DataRow item)
        {
            return new Empresa()
            {
                Id = item.Field<int>("emp_id"),
                Ruc = item.Field<string>("emp_ruc"),
                RazonSocial = item.Field<string>("emp_razon_social"),
                NombreComercial = item.Field<string>("emp_nombre"),
                RepresentanteLegal = item.Field<string>("emp_representante"),
                Direccion = item.Field<string>("emp_direccion"),
                Telefono = item.Field<string>("emp_telefono"),
            };
        }

        public List<Empresa> SeleccionarListaEmpresas(string razon,int itemsPorPagina, int numeroPagina, out int maxItems)
        {
            maxItems = 0;
            List<Empresa> result = new List<Empresa>();
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    int numeroPag = numeroPagina * itemsPorPagina;
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("razon", razon);
                    itemListDictionary.Add("Offset", numeroPag);
                    itemListDictionary.Add("Limit", itemsPorPagina);
                    itemListDictionary.Add("MaxItems", maxItems);
                 
                    var query = obj.GetQuery(Queries.Default.ObtenerTodasLasEmpresasPaginadas, Queries.Default.ObtenerTodasLasEmpresasCount, itemListDictionary, out maxItems);

                    if (query != null)
                    {
                        foreach (DataRow item in query.Rows)
                        {
                            result.Add(MappeoOrigen(item));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.ExLogger(ex);
            }
            return result;
        }


    }
}
