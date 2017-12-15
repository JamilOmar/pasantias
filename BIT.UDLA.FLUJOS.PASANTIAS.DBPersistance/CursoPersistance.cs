using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIT.UDLA.FLUJOS.PASANTIAS.Comun;
using db = BIT.UDLA.FLUJOS.PASANTIAS.DbConnector;
using System.Collections.Specialized;
using BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance.Properties;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using System.Data;

namespace BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance
{
    public class CursoPersistance
    {
        public bool Insertar(Entities.Curso item)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    #region Parametros
                    ListDictionary parametros = new ListDictionary();
                    parametros.Add("PER_ID", item.IdPersona);
                    parametros.Add("PAI_ID", item.IdPais);
                    parametros.Add("CUR_NOMBRE", item.Nombre.Trim());
                    parametros.Add("CUR_INSTITUCION", item.Institucion.Trim());
                    parametros.Add("CUR_FECHA_INICIO", item.Fecha);
                    parametros.Add("CUR_DURACION", item.Duracion);
                    parametros.Add("CUR_DESCRIPCION", item.Descripcion.Trim());
                    parametros.Add("CUR_ESTADO", item.Estado);
                    #endregion
                  
                  
                    var result = obj.insertQuery(Queries.Default.InsertarCurso, parametros);
                    return result <= 0;
                }
            }
            catch (Exception ex)
            {
                Logger.ExLogger(ex);
            }
            return false;
        }



        public bool Eliminar(Entities.Curso item)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    #region Parametros
                    ListDictionary parametros = new ListDictionary();
                    parametros.Add("CUR_ID", item.Id);
                   
                    #endregion


                    var result = obj.deleteQuery(Queries.Default.EliminarCurso, parametros);
                    return result <= 0;
                }
            }
            catch (Exception ex)
            {
                Logger.ExLogger(ex);
            }
            return false;
        }




        public Curso Actualizar(Curso item)
        {
            using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
            {
                ListDictionary parametros = new ListDictionary();
                parametros.Add("PER_ID", item.IdPersona);
                parametros.Add("PAI_ID", item.IdPais);
                parametros.Add("CUR_NOMBRE", item.Nombre.Trim());
                parametros.Add("CUR_INSTITUCION", item.Institucion.Trim());
                parametros.Add("CUR_FECHA_INICIO", item.Fecha);
                parametros.Add("CUR_DURACION", item.Duracion);
                parametros.Add("CUR_DESCRIPCION", item.Descripcion.Trim());
                parametros.Add("CUR_ESTADO", item.Estado);

                ListDictionary filter = new ListDictionary();
                filter.Add("Cur_ID", item.Id);

                var result = obj.updateQuery(Queries.Default.ActualizarCurso, parametros, filter);
                return null;
            }
        }

        public Curso Seleccionar(Curso item)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary parametros = new ListDictionary();
                    parametros.Add("Cur_ID", item.Id);
                    parametros.Add("per_ID", item.IdPersona);

                    DataRow result = (from hojaVida in obj.ExecuteQuery(Queries.Default.SeleccionarCurso, parametros).AsEnumerable()
                                      select hojaVida
                                      ).FirstOrDefault();

                    if (result != null)
                        return MapToItem(result);
                }
            }
            catch (Exception ex)
            {
                Logger.ExLogger(ex);
            }
            return null;
        }

        public List<Curso> SeleccionarCursos(int idPersona)
        {
            List<Curso> result = new List<Curso>();
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {

                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("PER_ID", idPersona);



                    var query = obj.ExecuteQuery(Queries.Default.ObtenerTodosLosCursosPorPersona, itemListDictionary);

                    if (query != null)
                    {
                        foreach (DataRow item in query.Rows)
                        {
                            result.Add(MapToItem(item));
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

        public Curso MapToItem(DataRow item)
        {
            Curso curso = new Curso();
            curso.Id = item.Field<int?>("Cur_ID");
            curso.IdPersona = item.Field<int?>("PER_ID");
            curso.IdPais = item.Field<int?>("PAI_ID");
            curso.Nombre = item.Field<string>("CUR_NOMBRE");
            curso.Institucion = item.Field<string>("CUR_INSTITUCION");
            curso.Fecha = item.Field<DateTime?>("CUR_FECHA_INICIO");
            curso.Duracion = item.Field<int?>("CUR_DURACION");
            curso.Descripcion = item.Field<string>("CUR_DESCRIPCION");
            curso.Estado = item.Field<int?>("CUR_ESTADO");
            return curso;
        }

        public bool ExisteCurso(int idCurso)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary parametros = new ListDictionary();
                    parametros.Add("CUR_ID", idCurso);

                    var result = obj.ExecuteQuery(Queries.Default.VerificarExistenciaCurso, parametros).AsEnumerable();
                    if (result.Count() > 0)
                        return true;
                }
            }
            catch (Exception ex)
            {
                Logger.ExLogger(ex);
            }
            return false;
        }



    }
}





