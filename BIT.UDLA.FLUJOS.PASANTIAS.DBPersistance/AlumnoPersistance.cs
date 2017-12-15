using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIT.UDLA.FLUJOS.PASANTIAS.Comun;
using System.Data;
using System.Collections.Specialized;
using db = BIT.UDLA.FLUJOS.PASANTIAS.DbConnector;
using BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance.Properties;
using BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;

namespace BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance
{
    public class AlumnoPersistance
    {
        public bool EsValido(User usuario, out string mensaje)
        {
            if (ValidarCuartaMatricula(usuario.MatriculaID, out mensaje) && ValidarResolucionRetiro(usuario.ID, out mensaje) && ValidarNivel(usuario.Nivel, usuario.CarreraID, usuario.PlanID, usuario.EspecialidadID, out mensaje) && ValidarDeudas(usuario.ID, out mensaje))
                return true;

            if (mensaje == "")
                mensaje = Mensajes.Default.ErrorValidacion;

            return false;
        }

        public User SeleccionarPorId(string id, out string mensaje)
        {
            mensaje = "";

            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.SAES))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("@p1", Utils.QuitarDominio(id));

                    DataRow query = (from result in obj.ExecuteQuery(Queries.Default.SeleccionarAlumno, itemListDictionary).AsEnumerable()
                                     select result).FirstOrDefault();

                    if (query != null)
                        return MappeoOrigen(query);
                    else
                        mensaje = Mensajes.Default.SeleccionarAlumno;
                }
            }
            catch (Exception ex)
            {
                Logger.ExLogger(ex);
                mensaje = Mensajes.Default.Excepcion;
            }

            return null;
        }

        public int ObtenerNivel(string matricula, string carrera, string plan, string especialidad, out string mensaje)
        {
            mensaje = "";

            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.SAES))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("@p1", matricula);
                    itemListDictionary.Add("@p2", carrera);
                    itemListDictionary.Add("@p3", plan);
                    itemListDictionary.Add("@p4", especialidad);

                    DataRow query = (from result in obj.ExecuteQuery(Queries.Default.SeleccionarNivel, itemListDictionary).AsEnumerable()
                                     select result).FirstOrDefault();

                    if (query != null && query[0].ToString() != "")
                        return int.Parse(query[0].ToString());
                    else
                        mensaje = Mensajes.Default.SeleccionarNivel;
                }
            }
            catch (Exception ex)
            {
                Logger.ExLogger(ex);
                mensaje = Mensajes.Default.Excepcion;
            }

            return -1;
        }

        public string[] ObtenerTutor(string alumno, out string mensaje)
        {
            mensaje = "";

            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.SAES))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("@p1", alumno);

                    DataRow query = (from result in obj.ExecuteQuery(Queries.Default.SeleccionarTutor, itemListDictionary).AsEnumerable()
                                     select result).FirstOrDefault();

                    if (query != null)
                        return DecodificarTutor(query);
                    else
                        mensaje = Mensajes.Default.SeleccionarTutor;
                }
            }
            catch (Exception ex)
            {
                Logger.ExLogger(ex);
                mensaje = Mensajes.Default.Excepcion;
            }

            return null;
        }

        public bool ActualizarMateria(string id, string materia, float nota)
        {
            //cambiar aca
            return true;
        }

        public User MappeoOrigen(DataRow item)
        {
                 var ApellidoPaterno = Utils.TrimText((item.Field<string>("pers_apat")));
                 var ApellidoMaterno = Utils.TrimText((item.Field<string>("pers_amat")));
            return new User()
            {
                ID = item.Field<int>("alum_rut").ToString(),
                DV = item.Field<string>("alum_dv"),
                Cedula = (item.Field<int>("alum_rut").ToString() + item.Field<string>("alum_dv")).PadLeft(10, '0'),
                MatriculaID = item.Field<decimal>("alum_nmat").ToString(),
                CarreraID = item.Field<string>("alum_carr"),
                PlanID = item.Field<string>("alum_plan"),
                EspecialidadID = item.Field<string>("alum_espe"),
                Nombres = Utils.TrimText( item.Field<string>("pers_nomb")),
                Apellidos = ApellidoPaterno + " " +ApellidoMaterno,
                Sexo = DecodificarSexo(item.Field<string>("pers_sexo")),
                EstadoCivil = DecodificarEstadoCivil(item.Field<string>("pers_eciv")),
                FechaNacimiento = item.Field<DateTime>("pers_fnac"),
                Direccion = item.Field<string>("dire_dire").Trim(' ', '\t'),
                Telefono = Utils.TrimText(item.Field<string>("dire_fono")),
                Celular = Utils.TrimText(item.Field<string>("dire_fax")),
                Email = Utils.TrimText(item.Field<string>("dire_mail")),
                Ciudad = Utils.TrimText(item.Field<string>("ciud_desc")),
                Carrera = Utils.TrimText(item.Field<string>("carr_desl")),
                Jornada = DecodificarJornada(item.Field<string>("alum_carr"))
            };
        }

        #region metodos de decodificacion

        private string DecodificarSexo(string valor)
        {
            switch (valor)
            {
                case "M":
                    return "Masculino";
                case "F":
                    return "Femenino";
                default:
                    return "";
            }
        }

        private string DecodificarEstadoCivil(string valor)
        {
            switch (valor)
            {
                case "C":
                    return "Casado";
                case "D":
                    return "Divorviado";
                case "S":
                    return "Soltero";
                case "V":
                    return "Viudo";
                case "U":
                    return "Union Libre";
                default:
                    return "";
            }
        }

        private string[] DecodificarTutor(DataRow item)
        {
            return new string[]
            {
                item.Field<string>("pers_nomb") + " " + item.Field<string>("pers_apat"),
                (item.Field<int>("pers_rutp").ToString() + item.Field<string>("pers_dve")).PadLeft(10, '0')
            };
        }

        private string DecodificarJornada(string valor)
        {
            switch (valor.Substring(valor.Length - 1))
            {
                case "1":
                    return "Diurno";
                case "2":
                    return "Nocturno";
                case "5":
                    return "Semipresencial";
                case "6":
                    return "Programa Profesional Nocturno";
                default:
                    return "";
            }
        }

        #endregion

        #region metodos privados

        private bool ValidarCuartaMatricula(string id, out string mensaje)
        {
            mensaje = "";

            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.SAES))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("@p1", id);

                    DataRow query = (from result in obj.ExecuteQuery(Queries.Default.ValidarCuartaMatricula, itemListDictionary).AsEnumerable()
                                     select result).FirstOrDefault();

                    if (query != null)
                    {
                        mensaje = query[0].ToString() == "0" ? "" : Mensajes.Default.ValidarCuartaMatricula;
                        return query[0].ToString() == "0";
                    }
                    else
                        mensaje = Mensajes.Default.ValidarCuartaMatricula;
                }
            }
            catch (Exception ex)
            {
                Logger.ExLogger(ex);
                mensaje = Mensajes.Default.Excepcion;
            }

            return false;
        }

        private bool ValidarResolucionRetiro(string id, out string mensaje)
        {
            mensaje = "";

            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.SAES))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("@p1", id);

                    DataRow query = (from result in obj.ExecuteQuery(Queries.Default.ValidarResolucionRetiro, itemListDictionary).AsEnumerable()
                                     select result).FirstOrDefault();

                    if (query != null)
                    {
                        mensaje = query[0].ToString() == "0" ? "" : Mensajes.Default.ValidarResolucionRetiro;
                        return query[0].ToString() == "0";
                    }
                    else
                        mensaje = Mensajes.Default.ValidarResolucionRetiro;
                }
            }
            catch (Exception ex)
            {
                Logger.ExLogger(ex);
                mensaje = Mensajes.Default.Excepcion;
            }

            return false;
        }

        private bool ValidarNivel(int nivel, string carrera, string plan, string especialidad, out string mensaje)
        {
            mensaje = "";

            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.SAES))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("@p1", carrera);
                    itemListDictionary.Add("@p2", plan);
                    itemListDictionary.Add("@p3", especialidad);

                    DataRow query = (from result in obj.ExecuteQuery(Queries.Default.ValidarNivel, itemListDictionary).AsEnumerable()
                                     select result).FirstOrDefault();

                    if (query != null)
                    {
                        mensaje = nivel >= int.Parse(query[0].ToString()) ? "" : Mensajes.Default.ValidarNivel;
                        return nivel >= int.Parse(query[0].ToString());
                    }
                    else
                        mensaje = Mensajes.Default.ValidarNivel;
                }
            }
            catch (Exception ex)
            {
                Logger.ExLogger(ex);
                mensaje = Mensajes.Default.Excepcion;
            }

            return false;
        }

        private bool ValidarDeudas(string id, out string mensaje)
        {
            mensaje = "";
            bool result = true;

            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.SAES))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("id", id);

                    var query = obj.ExecuteQuery(Queries.Default.ValidarDeudas, itemListDictionary).AsEnumerable();

                    if (query != null)
                    {
                        foreach (DataRow d in query)
                            if (d[1].ToString().Trim() == "F")
                                if (d[2].ToString().ToLower().IndexOf("cuota morosa") != -1)
                                {
                                    result = false;
                                    mensaje = Mensajes.Default.ValidarDeudas;
                                    break;
                                }
                        return result;
                    }
                    else
                        mensaje = Mensajes.Default.ValidarDeudas;
                }
            }
            catch (Exception ex)
            {
                Logger.ExLogger(ex);
                mensaje = Mensajes.Default.Excepcion;
            }

            return false;
        }

        #endregion
    }
}
