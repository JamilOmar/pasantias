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
using BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties;
using BIT.UDLA.FLUJOS.PASANTIAS.Constants;

namespace BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance
{
    public class MateriaPersistance
    {

        public Materia Seleccionar(Materia item)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.SAES))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("@p1", item.ID);

                    DataRow query = (from materia in obj.ExecuteQuery(Queries.Default.SeleccionarMateria, itemListDictionary).AsEnumerable()
                                     select materia).FirstOrDefault();

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

        public Materia SeleccionarPorId(string id)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.SAES))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("@p1", id);

                    DataRow query = (from materia in obj.ExecuteQuery(Queries.Default.SeleccionarMateriaPorId, itemListDictionary).AsEnumerable()
                                     select materia).FirstOrDefault();

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
        public Materia SeleccionarPorIdSupervision(string id,string matricula)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.SAES))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("@p1", id);
                    itemListDictionary.Add("@p2", matricula);
                    DataRow query = (from materia in obj.ExecuteQuery(Queries.Default.SeleccionarMateriaPorIdSupervision, itemListDictionary).AsEnumerable()
                                     select materia).FirstOrDefault();

                    if (query != null)
                    {
                        return MappeoSupervision(query);
                    }
                }
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
            }
            return null;
        }

        public Materia MappeoOrigen(DataRow item)
        {
            Materia materia = new Materia();
            materia.ID = item.Field<string>("pert_asig");
            materia.Nombre = item.Field<string>("asig_desc");
            materia.Tipo = item.Field<string>("asig_prac");
            materia.Nivel = item.Field<Int16>("pert_nive");
            if(!item.IsNull("asig_hpra"))
            materia.Horas = item.Field<Int16>("asig_hpra");
            materia.DocenteID = DecodificarDocente(item.Field<string>("docente"), 0);
            materia.Docente = DecodificarDocente(item.Field<string>("docente"), 1);
            return materia;
        }
        public Materia MappeoSupervision(DataRow item)
        {
            Materia materia = new Materia();
            materia.ID = item.Field<string>("carg_asig");
            materia.Nombre = item.Field<string>("asig_desc");
            materia.Tipo = item.Field<string>("asig_prac");
            materia.Nivel = 0;
            materia.Horas = item.Field<Int16>("asig_hpra");
            materia.DocenteID = DecodificarDocente(item.Field<string>("docente"), 0);
            materia.Docente = DecodificarDocente(item.Field<string>("docente"), 1);
            return materia;
        }

        public List<Materia> SeleccionarListaMaterias(string carrera, string plan, string especialidad, string tipo)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.SAES))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("@p1", carrera);
                    itemListDictionary.Add("@p2", plan);
                    itemListDictionary.Add("@p3", especialidad);

                    var query = obj.ExecuteQuery(Queries.Default.SeleccionarListaMaterias, itemListDictionary).AsEnumerable();

                    List<Materia> result = new List<Materia>();
                    string[] tipoD = DecodificarTipoPasantia(tipo);
                    foreach (var item in query)
                    {
                        result.Add(MappeoOrigen(item));
                    }

                    return result.Where(i => tipoD.Contains(i.Tipo)).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.ExLogger(ex);
            }
            return new List<Materia>();
        }


        public List<Materia> SeleccionarListaMateriasSupervision(string matricula)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.SAES))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("@p1", matricula);
                 

                    var query = obj.ExecuteQuery(Queries.Default.SeleccionarListaMateriasSupervision, itemListDictionary).AsEnumerable();

                    List<Materia> result = new List<Materia>();
                    foreach (var item in query)
                    {
                        result.Add(MappeoSupervision(item));
                    }

                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.ExLogger(ex);
            }
            return new List<Materia>();
        }


        private void ObtenerParametrosConexion(string tipoPasantia, out queries.DBConnectionType dbcontype, out string queryUpsert, out string querySelect)
        {
            switch (tipoPasantia)
            {
                case FlujoConstantes.CON_SUPERVISION:
                    dbcontype = Constants.DBConnectionType.BEMPLEO;
                    queryUpsert = Queries.Default.InsertarNotaBE;
                    querySelect = Queries.Default.ConsultarNotaBE;
                    break;
                case FlujoConstantes.SIN_SUPERVISION:
                    dbcontype = Constants.DBConnectionType.SAES;
                    queryUpsert = Queries.Default.InsertarNotaSAES;
                    querySelect = Queries.Default.ConsultarNotaSAES;
                    break;
                case FlujoConstantes.CON_TRABAJO:
                    dbcontype = Constants.DBConnectionType.SAES;
                    queryUpsert = Queries.Default.InsertarNotaSAES;
                    querySelect = Queries.Default.ConsultarNotaSAES;
                    break;
                default:
                    dbcontype = Constants.DBConnectionType.BEMPLEO;
                    queryUpsert = Queries.Default.InsertarNotaBE;
                    querySelect = Queries.Default.ConsultarNotaBE;
                    break;
            }
        }

        public int ObtenerHorasActuales(PasantiasPreProfesionales item)
        {
            queries.DBConnectionType dbcontype;
            string queryUpsert;
            string querySelect;
 
            ObtenerParametrosConexion(item.TipoPasantiaEnum, out dbcontype, out queryUpsert, out querySelect);

            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(dbcontype))
                {
                    ListDictionary notaSelect = new ListDictionary();
                    notaSelect.Add("@p1", item.Matricula);
                    notaSelect.Add("@p2", item.CodigoDeMateria);

                    DataRow queryS = (from nota in obj.ExecuteQuery(querySelect, notaSelect).AsEnumerable()
                                      select nota).FirstOrDefault();

                    if (queryS != null && queryS[0].ToString() != "")
                        return int.Parse(queryS[0].ToString());
                    else return 0;
                }
            }
            catch (Exception ex)
            {
                Logger.ExLogger(ex);
            }

            return -1;
        }

        public bool GuardarNota(PasantiasPreProfesionales item, string tipo, out string mensaje)
        {
            queries.DBConnectionType dbcontype;
            string queryUpsert;
            string querySelect;

            ObtenerParametrosConexion(item.TipoPasantiaEnum, out dbcontype, out queryUpsert, out querySelect);
            mensaje = "";

            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(dbcontype))
                {
                    ListDictionary notaLD = new ListDictionary();
                    notaLD.Add("@prac_nmat", item.Matricula);
                    notaLD.Add("@prac_carr", item.CodigoCarrera);
                    notaLD.Add("@prac_prac", tipo);
                    notaLD.Add("@prac_inic", item.FechaInicio);
                    notaLD.Add("@prac_term", item.FechaFin);
                    notaLD.Add("@prac_hora", item.NumeroHorasEjecutadas);
                    notaLD.Add("@prac_mate", item.CodigoDeMateria);
                    notaLD.Add("@prac_empr", item.IdEmpresa);
                    notaLD.Add("@prac_esta", item.HorasActualesEnElSistemaSAES + item.NumeroHorasEjecutadas < item.MaximoHorasMateria ? "P" : "A");
                    notaLD.Add("@prac_obse", item.ObservacionesDeRegistroDeHorasSAES);
                    obj.ExecuteGenericQuery(queryUpsert, notaLD);
                }

                return true;
            }
            catch (Exception ex)
            {
                mensaje = Mensajes.Default.Excepcion;
                Logger.ExLogger(ex);
            }

            return false;
        }

        #region metodos de decodificacion

        private string DecodificarDocente(string valor, int posicion)
        {
            if (!string.IsNullOrEmpty(valor))
                return valor.Split(new char[] { '|' })[posicion];

            return "";
        }

        private string[] DecodificarTipoPasantia(string tipo)
        {
            switch (tipo)
            {
                case FlujoConstantes.CON_SUPERVISION:
                    return new string[] { "N" };
                case FlujoConstantes.CON_TRABAJO:
                    return new string[] { "I", "F" };
                case FlujoConstantes.SIN_SUPERVISION:
                    return new string[] { "I", "F" };
                default:
                    return new string[] { "" };
            }
        }

        #endregion
    }
}
