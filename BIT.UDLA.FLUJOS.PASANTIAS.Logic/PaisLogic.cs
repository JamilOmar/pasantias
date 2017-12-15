using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using entidades = BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
namespace BIT.UDLA.FLUJOS.PASANTIAS.Logic
{
    public class PaisLogic
    {
        PaisPersistance pais = new PaisPersistance();
        public List<entidades.Pais> SeleccionarListaPaises()
        {
            var data = pais.SeleccionarListaPaises();
            data.Add(new Pais { Id = -1, Nombre = "[SELECCIONE]" });
            return data;
        }
    }
}
