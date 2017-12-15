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
    public class AcademicoPersistance
    {
        public Academico SeleccionarPorMatricula(string matricula)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("matricula", matricula);

                    DataRow query = (from academico in obj.ExecuteQuery(Queries.Default.SeleccionarEstudianteSAES, itemListDictionary).AsEnumerable()
                                     select academico).FirstOrDefault();

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

        Academico MappeoOrigen(DataRow item)
        {
            return new Academico()
            {
                Id = item.Field<int>("id"),
                Nombres = item.Field<string>("nombres"),
                Apellidos = item.Field<string>("apellidos"),
                Cedula = item.Field<string>("cedula"),
                Matricula = item.Field<string>("matricula"),
                Direccion = item.Field<string>("DIRECCION"),
                Telefono = item.Field<string>("TELEFONO"),
                Celular = item.Field<string>("CELULAR"),
                Ciudad = item.Field<string>("CIUDAD"),
                Genero = item.Field<string>("GENERO"),
                FechaNacimiento = item.Field<string>("FechaNACIMIENTO"),
                Estado= item.Field<string>("Estado"),
                Modalidad = item.Field<string>("MODALIDAD"),
                Disponibilidad = item.Field<string>("DISPONIBILIDAD"),
                Carrera1 = item.Field<string>("carrera1"),
                NivelCarrera1 = item.Field<string>("nivel1"),
                Carrera2 = item.Field<string>("carrera2"),
                NivelCarrera2 = item.Field<string>("nivel2"),
                Nivel= item.Field<string>("Nivel"),
                Email = item.Field<string>("EMAIL"),
            };
        }
    }
}
