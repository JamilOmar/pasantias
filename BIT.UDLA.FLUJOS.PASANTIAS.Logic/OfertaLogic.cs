using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using entidades = BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using db = BIT.UDLA.FLUJOS.PASANTIAS.DbConnector;
using queries = BIT.UDLA.FLUJOS.PASANTIAS.Constants;
using BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.Comun;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Logic
{
    public class OfertaLogic
    {
        OfertaLaboralPersistance oferta = new OfertaLaboralPersistance();
        public OfertaLaboral SeleccionarPorId(int id)
        {
            try
            {
                return oferta.SeleccionarPorId(id);
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
                throw ex;
            }
            return null;
        }
        public List<OfertaLaboral> SeleccionarListaOfertas(int itemsPorPagina, int numeroPagina, out int maxItems)
        {
            try
            {
                return oferta.SeleccionarListaOfertas(itemsPorPagina, numeroPagina, out maxItems);
          
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
                throw ex;
            }
            return null;
        }
        public PasantiasPreProfesionales Insertar( PasantiasPreProfesionales pasantia)
        {
            try
            {
                pasantia.EsOfertaLaboral = true;
                oferta.Insertar((int)pasantia.IDOfertaLaboral.Value,(int)pasantia.PERID.Value);
                return pasantia;
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
                throw ex;
            }
           
           
        }
        public bool? EsOfertaValida(int oferID, int perID)
        {
            return oferta.EsOfertaValida(oferID, perID);
        }
            
    }
}
