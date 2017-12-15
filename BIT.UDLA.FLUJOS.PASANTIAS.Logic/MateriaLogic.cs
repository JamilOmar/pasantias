using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using entidades = BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.Constants.Properties;
namespace BIT.UDLA.FLUJOS.PASANTIAS.Logic
{
    public class MateriaLogic
    {
        MateriaPersistance materias = new MateriaPersistance();


        public entidades.Materia Seleccionar(entidades.Materia item)
        {
            return materias.Seleccionar(item);
        }

        public List<Materia> SeleccionarListaMaterias(string carrera, string plan, string especialidad, string tipo,string matricula)
        {
            if(tipo.Equals(Constants.FlujoConstantes.CON_SUPERVISION))
                  return materias.SeleccionarListaMateriasSupervision(matricula);
                else
            return materias.SeleccionarListaMaterias(carrera, plan, especialidad, tipo);
        }

        public entidades.Materia SeleccionarPorId(string id)
        {
            return materias.SeleccionarPorId(id);
        }
        public entidades.Materia SeleccionarPorIdSupervision(string id,string matricula)
        {
            return materias.SeleccionarPorIdSupervision(id,matricula);
        }

        public int ObtenerDocenteMOSSID(string cedula, out string mensaje)
        {
            string loginName = Comun.Utils.ObtenerUsernameAD(cedula, out mensaje);

            loginName = "usrbit03";
            if (loginName != "")
                return MossPersistance.UserPersistence.GetUserID(loginName,true, out mensaje);
            else
                return -1;
        }

        public bool GuardarNota(PasantiasPreProfesionales item, out string mensaje)
        {
            mensaje = "";

            if (item.NumeroHorasEjecutadas < 0)
            {
                mensaje = Mensajes.Default.ObtenerHoras;
                return false;
            }

            if ((item.HorasActualesEnElSistemaSAES + item.NumeroHorasEjecutadas > item.MaximoHorasMateria) && item.TipoPasantiaEnum != BIT.UDLA.FLUJOS.PASANTIAS.Constants.FlujoConstantes.CON_SUPERVISION)
                mensaje = Mensajes.Default.MaxHoras;
            else
            {
                Materia materia = SeleccionarPorId(item.CodigoDeMateria);
                return materias.GuardarNota(item, materia.Tipo, out mensaje);
            }

            return false;
        }

        public int ObtenerHorasActuales(PasantiasPreProfesionales item)
        {
            return materias.ObtenerHorasActuales(item);
        }
    }
}
