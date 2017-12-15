using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.MossPersistance;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Logic
{
    public class ActividadesLogic
    {
        public bool Insertar(Actividades item, out int? id)
        {
            try
            {
                ActividadesPersistance actividades = new ActividadesPersistance();
                return actividades.Insertar(item, out id);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
           
        }
        public Actividades Actualizar(Actividades item)
        {
            try
            {
                ActividadesPersistance actividades = new ActividadesPersistance();
                return actividades.Actualizar(item);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }
        public List<Actividades> SeleccionarPaginado(int startRowIndex, int maximumRows, int idPasantia, out int itemsCount)
        {
            try
            {
                ActividadesPersistance actividades = new ActividadesPersistance();
                return actividades.SeleccionarPaginado(startRowIndex, maximumRows, idPasantia, out itemsCount);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }
        public Actividades SeleccionarPorId(int id)
        {
            try
            {
                ActividadesPersistance actividades = new ActividadesPersistance();
                return actividades.SeleccionarPorId(id);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
          
        }
    }
}
