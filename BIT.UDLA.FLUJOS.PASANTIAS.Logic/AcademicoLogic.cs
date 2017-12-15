using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Logic
{
    public class AcademicoLogic
    {
        AcademicoPersistance academicoPersistance = new AcademicoPersistance();
        public Academico SeleccionarPorMatricula(string matricula)
        {
            try
            {
                return academicoPersistance.SeleccionarPorMatricula(matricula);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }
    }
}
