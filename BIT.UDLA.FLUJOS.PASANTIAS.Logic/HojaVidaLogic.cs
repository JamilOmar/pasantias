using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance;
using word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;


namespace BIT.UDLA.FLUJOS.PASANTIAS.Logic
{
    public class HojaVidaLogic
    {
        HojaVidaPersistance hojaVidaPersistance = new HojaVidaPersistance();

        public int Insertar(HojaVida item)
        {
            try
            {
              var val = hojaVidaPersistance.Insertar(item);
              if (val == 0)
                  throw new Exception("PER_ID no puede ser 0");
              return val;
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }

        public HojaVida Seleccionar(HojaVida item)
        {
            try
            {
                return hojaVidaPersistance.Seleccionar(item);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }


        public HojaVida SeleccionarPorMatricula(string matricula)
        {
            try
            {
                return hojaVidaPersistance.SeleccionarPorMatricula(matricula);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }

        public bool ExisteHojaVida(string matricula)
        {
            try
            {
                return hojaVidaPersistance.ExisteHojaVida(matricula);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }

        public HojaVida Actualizar(HojaVida hojaVida)
        {
            try
            {
                return hojaVidaPersistance.Actualizar(hojaVida);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }

        public HojaVida SeleccionarCamposEditablesPorMatricula(string matricula)
        {
            try
            {
                return hojaVidaPersistance.SeleccionarCamposEditablesPorMatricula(matricula);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }
        public KeyValuePair<int, string> ObtenerCarreraSegunSAES(string idSaes)
        {
            try
            {
                return hojaVidaPersistance.ObtenerCarreraSegunSAES(idSaes);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }

        }

       
    }
}