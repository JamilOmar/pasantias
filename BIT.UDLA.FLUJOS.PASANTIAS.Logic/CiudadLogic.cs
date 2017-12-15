using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using entidades = BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
namespace BIT.UDLA.FLUJOS.PASANTIAS.Logic
{
    public class CiudadLogic
    {
        CiudadPersistance ciudad = new CiudadPersistance();
        public List<entidades.Ciudad> SeleccionarListaCiudades()
        {
            var data = ciudad.SeleccionarListaCiudades();
            data.Add(new Ciudad { ID = -1, Nombre = "[SELECCIONE]" });
            return data;
        }
    }
}
