using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIT.UDLA.FLUJOS.PASANTIAS.MossPersistance;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Logic
{
    public class PasantiasPreprofesionalesLogic
    {
        PasantiasPreProfesionalesPersistence pasantiasLogic = new PasantiasPreProfesionalesPersistence();

        public bool Insertar(PasantiasPreProfesionales item, out int? id)
        {
            try
            {
                id = 0;
                return pasantiasLogic.Insertar(item, out id);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }

        public PasantiasPreProfesionales Actualizar(PasantiasPreProfesionales item)
        {
            try
            {
                return pasantiasLogic.Actualizar(item);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }

       

        public PasantiasPreProfesionales Seleccionar(PasantiasPreProfesionales item)
        {
            try
            {
                return pasantiasLogic.Seleccionar(item);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }

        public PasantiasPreProfesionales SeleccionarPorId(int id)
        {
            try
            {
                return pasantiasLogic.SeleccionarPorId(id);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }


        public bool CambiarEstado(int id, string estado)
        {
            try
            {
                return pasantiasLogic.CambiarEstado(id, estado);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }



        public string GetEstado(int id)
        {
            try
            {
                return pasantiasLogic.GetEstado(id);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }
        public List<PasantiasPreProfesionales> SeleccionarAlumnosParaEmpresa(string estado)
        {
            try
            {
                return pasantiasLogic.SeleccionarAlumnosParaEmpresa(estado);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }
        public List<PasantiasPreProfesionales> SeleccionarPasantiasActivas()
        {
            try
            {
                return pasantiasLogic.SeleccionarPasantiasActivas();
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }
        public bool CambiarEstadoSeleccionadoAlumnoEmpresa(int id, string estado, bool esSeleccionado)
        {
            try
            {
                return pasantiasLogic.CambiarEstadoSeleccionadoAlumnoEmpresa(id, estado, esSeleccionado);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }
        public bool CambiarEstadoSeleccionadoAlumnoDocente(int id, string estado, bool esSeleccionado)
        {
            try
            {
                return pasantiasLogic.CambiarEstadoSeleccionadoAlumnoDocente(id, estado, esSeleccionado);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }
        public List<PasantiasPreProfesionales> SeleccionarAlumnosParaEmpresa(int startRowIndex, int maximumRows, string estado, out int itemsCount)
        {
            try
            {
                return pasantiasLogic.SeleccionarAlumnosParaEmpresa(startRowIndex,
                    maximumRows, estado, out  itemsCount);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }
        public List<PasantiasPreProfesionales> SeleccionarAlumnosParaDocente(int startRowIndex, int maximumRows, string estado, out int itemsCount)
        {
            try
            {
                return pasantiasLogic.SeleccionarAlumnosParaDocente(startRowIndex,
                    maximumRows, estado, out  itemsCount);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }

         public List<PasantiasPreProfesionales> SeleccionarPreCancelados(int startRowIndex, int maximumRows,  out int itemsCount,string cancelado)
        {
            try
            {
                return pasantiasLogic.SeleccionarPreCancelados(startRowIndex,
                    maximumRows, out  itemsCount,cancelado);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }
    }
}
