using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.MossPersistance;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Logic
{
    public class VisitasLogic
    {
        public bool Insertar(Visitas item, out int? id)
        {

            try
            {
                VisitasPersistance visita = new VisitasPersistance();
                return visita.Insertar(item, out id);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }
        public Visitas Actualizar(Visitas item)
        {
            try
            {
                VisitasPersistance visita = new VisitasPersistance();
                return visita.Actualizar(item);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }
        public List<Visitas> SeleccionarPaginado(int startRowIndex, int maximumRows, int idPasantia, out int itemsCount)
        {
            try
            {
                VisitasPersistance visita = new VisitasPersistance();
                return visita.SeleccionarPaginado(startRowIndex, maximumRows, idPasantia, out itemsCount);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }
        public Visitas SeleccionarPorId(int id)
        {
            try
            {
                VisitasPersistance visita = new VisitasPersistance();
                return visita.SeleccionarPorId(id);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }

        }
    }
}
