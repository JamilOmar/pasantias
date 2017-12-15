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
    public class HojaVidaPersistance
    {
        public int Insertar(Entities.HojaVida item)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    #region Parametros
                    ListDictionary hojaVidaLD = new ListDictionary();
                    hojaVidaLD.Add("PER_NOMBRES", item.Nombres.Trim());
                    hojaVidaLD.Add("PER_APELLIDOS", item.Apellidos.Trim());
                    hojaVidaLD.Add("PER_IDENTIFICACION", item.Cedula.Trim());
                    hojaVidaLD.Add("PER_MATRICULA", item.Matricula.Trim());
                    hojaVidaLD.Add("PER_DIRECCION", item.Direccion.Trim());
                    hojaVidaLD.Add("PER_TELEFONO1", item.Telefono.Trim());
                    hojaVidaLD.Add("PER_CELULAR", item.Celular.Trim());
                    hojaVidaLD.Add("PER_CIUDAD", item.Ciudad.Trim());
                    hojaVidaLD.Add("PER_GENERO", item.Genero.Trim());
                    hojaVidaLD.Add("PER_NACIMIENTO", item.FechaNacimiento);
                    hojaVidaLD.Add("PER_MODALIDAD_TRABAJO", item.Modalidad.Trim());
                    hojaVidaLD.Add("per_nivel_empleo", item.NivelEmpleo.Trim());
                    hojaVidaLD.Add("per_aspiracion", item.AspiracionSalarial);
                    hojaVidaLD.Add("per_institucion", item.Institucion.Trim());
                    hojaVidaLD.Add("per_estudios", item.Estudios);
                    hojaVidaLD.Add("per_nivelestudios", item.NivelEstudios);
                    hojaVidaLD.Add("per_lugar", item.EstudiosEn);

                    hojaVidaLD.Add("per_meritos", item.Meritos.Trim());
                    hojaVidaLD.Add("per_objetivo", item.Objetivo.Trim()); 
                    hojaVidaLD.Add("per_Actividades", item.OtrasActividades.Trim()); 

                    hojaVidaLD.Add("PER_DISPONIBILIDAD", item.Disponibilidad.Trim());
                    hojaVidaLD.Add("PER_EMAIL", item.Email);
                    hojaVidaLD.Add("PER_CARRERA1", item.Carrera1.Trim());
                    hojaVidaLD.Add("PER_NIVELC1", item.NivelCarrera1.Trim());
                    hojaVidaLD.Add("PER_CARRERA2", item.Carrera2.Trim());
                    hojaVidaLD.Add("PER_NIVELC2", item.NivelCarrera2.Trim());

                    hojaVidaLD.Add("PER_ESPANOL", item.Espanol.Trim());
                    hojaVidaLD.Add("PER_INGLES", item.Ingles.Trim());
                    hojaVidaLD.Add("PER_FRANCES", item.Frances.Trim());
                    hojaVidaLD.Add("PER_ALEMAN", item.Aleman.Trim());
                    hojaVidaLD.Add("PER_OTRO_IDIOMA", item.OtroIdioma.Trim());
                    hojaVidaLD.Add("PER_OTRO_IDIOMA_VALOR", item.OtroIdiomaValor.Trim());
                    hojaVidaLD.Add("PER_EMPRESA1", item.Empresa1.Trim());
                    hojaVidaLD.Add("PER_CARGO1", item.Cargo1.Trim());
                    hojaVidaLD.Add("PER_REFERENCIA1", item.JefeInmediato1.Trim());
                    hojaVidaLD.Add("PER_TEL_REF1", item.Telefono1.Trim());
                    hojaVidaLD.Add("PER_INICIO1", item.FechaInicio1);
                    hojaVidaLD.Add("PER_FIN1", item.FechaSalida1);
                    hojaVidaLD.Add("PER_RESPONSABILIDADES1", item.Responsabilidades1.Trim());

                    hojaVidaLD.Add("PER_EMPRESA2", item.Empresa2.Trim());
                    hojaVidaLD.Add("PER_CARGO2", item.Cargo2.Trim());
                    hojaVidaLD.Add("PER_REFERENCIA2", item.JefeInmediato2.Trim());
                    hojaVidaLD.Add("PER_TEL_REF2", item.Telefono2.Trim());
                    hojaVidaLD.Add("PER_INICIO2", item.FechaInicio2);
                    hojaVidaLD.Add("PER_FIN2", item.FechaSalida2);
                    hojaVidaLD.Add("PER_RESPONSABILIDADES2", item.Responsabilidades2.Trim());

                    hojaVidaLD.Add("PER_EMPRESA3", item.Empresa3.Trim());
                    hojaVidaLD.Add("PER_CARGO3", item.Cargo3.Trim());
                    hojaVidaLD.Add("PER_REFERENCIA3", item.JefeInmediato3.Trim());
                    hojaVidaLD.Add("PER_TEL_REF3", item.Telefono3.Trim());
                    hojaVidaLD.Add("PER_INICIO3", item.FechaInicio3);
                    hojaVidaLD.Add("PER_FIN3", item.FechaSalida3);
                    hojaVidaLD.Add("PER_RESPONSABILIDADES3", item.Responsabilidades3.Trim());
                    hojaVidaLD.Add("per_clase_empleo", item.Interesado);


                    hojaVidaLD.Add("per_fecha_creacion", DateTime.Now);
                    
                    #endregion
                  
                  
                    var result = obj.insertQuery(Queries.Default.InsertarHojaVida, hojaVidaLD);
                    return (int)result;
                }
            }
            catch (Exception ex)
            {
                Logger.ExLogger(ex);
            }
            return 0;
        }

        public HojaVida Actualizar(HojaVida item)
        {
            using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
            {

                ListDictionary hojaVidaLD = new ListDictionary();
                hojaVidaLD.Add("PER_NOMBRES", item.Nombres.Trim());
                hojaVidaLD.Add("PER_APELLIDOS", item.Apellidos.Trim());
                hojaVidaLD.Add("PER_IDENTIFICACION", item.Cedula.Trim());
                hojaVidaLD.Add("PER_DIRECCION", item.Direccion.Trim());
                hojaVidaLD.Add("PER_TELEFONO1", item.Telefono.Trim());
                hojaVidaLD.Add("PER_CELULAR", item.Celular.Trim());
                hojaVidaLD.Add("PER_CIUDAD", item.Ciudad.Trim());
                hojaVidaLD.Add("PER_GENERO", item.Genero.Trim());
                hojaVidaLD.Add("PER_NACIMIENTO", item.FechaNacimiento);
                hojaVidaLD.Add("PER_MODALIDAD_TRABAJO", item.Modalidad.Trim());
                hojaVidaLD.Add("PER_DISPONIBILIDAD", item.Disponibilidad.Trim());
                hojaVidaLD.Add("per_nivel_empleo", item.NivelEmpleo.Trim());
                hojaVidaLD.Add("per_aspiracion", item.AspiracionSalarial);
                hojaVidaLD.Add("per_institucion", item.Institucion.Trim());
                hojaVidaLD.Add("per_estudios", item.Estudios);
                hojaVidaLD.Add("per_nivelestudios", item.NivelEstudios);
                hojaVidaLD.Add("per_lugar", item.EstudiosEn);

                hojaVidaLD.Add("PER_EMAIL", item.Email.Trim());
                hojaVidaLD.Add("PER_CARRERA1", item.Carrera1.Trim());
                hojaVidaLD.Add("PER_NIVELC1", item.NivelCarrera1.Trim());
                hojaVidaLD.Add("PER_CARRERA2", item.Carrera2.Trim());
                hojaVidaLD.Add("PER_NIVELC2", item.NivelCarrera2.Trim());
                hojaVidaLD.Add("PER_ESPANOL", item.Espanol.Trim());
                hojaVidaLD.Add("PER_INGLES", item.Ingles.Trim());
                hojaVidaLD.Add("PER_FRANCES", item.Frances.Trim());
                hojaVidaLD.Add("PER_ALEMAN", item.Aleman.Trim());
                hojaVidaLD.Add("PER_OTRO_IDIOMA", item.OtroIdioma.Trim());
                hojaVidaLD.Add("PER_OTRO_IDIOMA_VALOR", item.OtroIdiomaValor.Trim());

                hojaVidaLD.Add("PER_EMPRESA1", item.Empresa1.Trim());
                hojaVidaLD.Add("PER_CARGO1", item.Cargo1.Trim());
                hojaVidaLD.Add("PER_REFERENCIA1", item.JefeInmediato1.Trim());
                hojaVidaLD.Add("PER_TEL_REF1", item.Telefono1.Trim());
                hojaVidaLD.Add("PER_INICIO1", item.FechaInicio1);
                hojaVidaLD.Add("PER_FIN1", item.FechaSalida1);
                hojaVidaLD.Add("PER_RESPONSABILIDADES1", item.Responsabilidades1.Trim());

                hojaVidaLD.Add("PER_EMPRESA2", item.Empresa2.Trim());
                hojaVidaLD.Add("PER_CARGO2", item.Cargo2.Trim());
                hojaVidaLD.Add("PER_REFERENCIA2", item.JefeInmediato2.Trim());
                hojaVidaLD.Add("PER_TEL_REF2", item.Telefono2.Trim());
                hojaVidaLD.Add("PER_INICIO2", item.FechaInicio2);
                hojaVidaLD.Add("PER_FIN2", item.FechaSalida2);
                hojaVidaLD.Add("PER_RESPONSABILIDADES2", item.Responsabilidades2.Trim());

                hojaVidaLD.Add("PER_EMPRESA3", item.Empresa3.Trim());
                hojaVidaLD.Add("PER_CARGO3", item.Cargo3.Trim());
                hojaVidaLD.Add("PER_REFERENCIA3", item.JefeInmediato3.Trim());
                hojaVidaLD.Add("PER_TEL_REF3", item.Telefono3.Trim());
                hojaVidaLD.Add("PER_INICIO3", item.FechaInicio3);
                hojaVidaLD.Add("PER_FIN3", item.FechaSalida3);
                hojaVidaLD.Add("PER_RESPONSABILIDADES3", item.Responsabilidades3.Trim());
                
                hojaVidaLD.Add("per_meritos", item.Meritos.Trim());
                hojaVidaLD.Add("per_objetivo", item.Objetivo.Trim()); 
                hojaVidaLD.Add("per_Actividades", item.OtrasActividades.Trim()); 
                hojaVidaLD.Add("per_clase_empleo", item.Interesado);
                hojaVidaLD.Add("per_fecha_actualizacion", DateTime.Now);

                ListDictionary filter = new ListDictionary();
                filter.Add("PER_MATRICULA", item.Matricula.Trim());
                var result = obj.updateQuery(Queries.Default.ActualizarHojaVida, hojaVidaLD, filter);
                return null;
            }
        }



        public HojaVida Seleccionar(HojaVida item)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary hojaVidaLD = new ListDictionary();
                    hojaVidaLD.Add("PER_MATRICULA", item.Matricula);

                    DataRow result = (from hojaVida in obj.ExecuteQuery(Queries.Default.SeleccionarHojaVida, hojaVidaLD).AsEnumerable()
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

        public HojaVida MapToItem(DataRow item)
        {
            HojaVida hojaVida = new HojaVida();
            hojaVida.Id = item.Field<int?>("PER_ID");
            hojaVida.Nombres = item.Field<string>("PER_NOMBRES");
            hojaVida.Apellidos = item.Field<string>("PER_APELLIDOS");
            hojaVida.Cedula = item.Field<string>("PER_IDENTIFICACION");
            hojaVida.Matricula = item.Field<string>("PER_MATRICULA");
            hojaVida.Direccion = item.Field<string>("PER_DIRECCION");
            hojaVida.Telefono = item.Field<string>("PER_TELEFONO1");
            hojaVida.Celular = item.Field<string>("PER_CELULAR");
            hojaVida.Ciudad = item.Field<string>("PER_CIUDAD");
            hojaVida.Genero = item.Field<string>("PER_GENERO");
            hojaVida.FechaNacimiento = item.Field<string>("PER_NACIMIENTO");
            hojaVida.Modalidad = item.Field<string>("PER_MODALIDAD_TRABAJO");
            hojaVida.Disponibilidad = item.Field<string>("PER_DISPONIBILIDAD");
            hojaVida.Institucion = item.Field<string>("per_institucion");
            hojaVida.Estudios = item.Field<int?>("per_estudios");
            hojaVida.NivelEstudios = item.Field<int?>("per_nivelestudios");
            hojaVida.EstudiosEn = item.Field<string>("per_lugar");
            hojaVida.Meritos = item.Field<string>("per_meritos");
            hojaVida.Objetivo = item.Field<string>("per_objetivo");
            hojaVida.OtrasActividades = item.Field<string>("per_Actividades");
            hojaVida.NivelEmpleo = item.Field<string>("per_nivel_empleo");
            hojaVida.AspiracionSalarial = item.Field<int?>("per_aspiracion");
            hojaVida.Email = item.Field<string>("PER_EMAIL");
            hojaVida.Carrera1 = item.Field<string>("PER_CARRERA1");
            hojaVida.NivelCarrera1 = item.Field<string>("PER_NIVELC1");
            hojaVida.Carrera2 = item.Field<string>("PER_CARRERA2");
            hojaVida.NivelCarrera2 = item.Field<string>("PER_NIVELC2");
            hojaVida.Espanol = item.Field<string>("PER_ESPANOL");
            hojaVida.Ingles = item.Field<string>("PER_INGLES");
            hojaVida.Frances = item.Field<string>("PER_FRANCES");
            hojaVida.Aleman = item.Field<string>("PER_ALEMAN");
            hojaVida.OtroIdioma = item.Field<string>("PER_OTRO_IDIOMA");
            hojaVida.OtroIdiomaValor = item.Field<string>("PER_POIDIOMA");
            hojaVida.Meritos = item.Field<string>("PER_MERITOS");

            hojaVida.Empresa1 = item.Field<string>("PER_EMPRESA1");
            hojaVida.Cargo1 = item.Field<string>("PER_CARGO1");
            hojaVida.JefeInmediato1 = item.Field<string>("PER_REFERENCIA1");
            hojaVida.Telefono1 = item.Field<string>("PER_TEL_REF1");
            hojaVida.FechaInicio1 = item.Field<string>("PER_INICIO1");
            hojaVida.FechaSalida1 = item.Field<string>("PER_FIN1");
            hojaVida.Responsabilidades1 = item.Field<string>("PER_RESPONSABILIDADES1");

            hojaVida.Empresa2 = item.Field<string>("PER_EMPRESA2");
            hojaVida.Cargo2 = item.Field<string>("PER_CARGO2");
            hojaVida.JefeInmediato2 = item.Field<string>("PER_REFERENCIA2");
            hojaVida.Telefono2 = item.Field<string>("PER_TEL_REF2");
            hojaVida.FechaInicio2 = item.Field<string>("PER_INICIO1");
            hojaVida.FechaSalida2 = item.Field<string>("PER_FIN2");
            hojaVida.Responsabilidades2 = item.Field<string>("PER_RESPONSABILIDADES2");

            hojaVida.Empresa3 = item.Field<string>("PER_EMPRESA3");
            hojaVida.Cargo3 = item.Field<string>("PER_CARGO3");
            hojaVida.JefeInmediato3 = item.Field<string>("PER_REFERENCIA3");
            hojaVida.Telefono3 = item.Field<string>("PER_TEL_REF3");
            hojaVida.FechaInicio3 = item.Field<string>("PER_INICIO3");
            hojaVida.FechaSalida3 = item.Field<string>("PER_FIN3");
            hojaVida.Responsabilidades3 = item.Field<string>("PER_RESPONSABILIDADES3");
            hojaVida.Interesado = item.Field<int?>("per_clase_empleo");
            return hojaVida;
        }

        public HojaVida SeleccionarPorMatricula(string matricula)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary hojaVidaLD = new ListDictionary();
                    hojaVidaLD.Add("PER_MATRICULA", matricula);

                    DataRow result = (from hojaVida in obj.ExecuteQuery(Queries.Default.SeleccionarHojaVida, hojaVidaLD).AsEnumerable()
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

        public HojaVida SeleccionarCamposEditablesPorMatricula(string matricula)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary hojaVidaLD = new ListDictionary();
                    hojaVidaLD.Add("PER_MATRICULA", matricula);

                    DataRow result = (from hojaVida in obj.ExecuteQuery(Queries.Default.SeleccionarHojaVida, hojaVidaLD).AsEnumerable()
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

        public bool ExisteHojaVida(string matricula)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary hojaVidaLD = new ListDictionary();
                    hojaVidaLD.Add("PER_Matricula", matricula);

                    var result = obj.ExecuteQuery(Queries.Default.VerificaExistenciaHojaVida, hojaVidaLD).AsEnumerable();
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

        public KeyValuePair<int, string> ObtenerCarreraSegunSAES(string idSaes)
        {
            string nombreSaes= string.Empty;
            int? codigoBolsaEmpleo=0;
            try
            {
               
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary Saes = new ListDictionary();
                    Saes.Add("SAES", idSaes);

                    var result = obj.ExecuteQuery(Queries.Default.SeleccionCarreraSAESBolsaEmpleo, Saes).AsEnumerable();
                    if (result.Count() > 0)
                    {
                        var item = result.FirstOrDefault();
                        codigoBolsaEmpleo = item.Field<int?>("CAR_BE");
                        nombreSaes = item.Field<string>("CAR_SAES_NOMBRE");
                        
                    }
                }
                return new KeyValuePair<int, string>(codigoBolsaEmpleo.Value, nombreSaes);
            }
            catch (Exception ex)
            {
                Logger.ExLogger(ex);
                throw ex;
            }
           
        }
       
    }
}





