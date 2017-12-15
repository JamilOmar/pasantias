using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using entidades = BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;


namespace BIT.UDLA.FLUJOS.PASANTIAS.Logic
{
    public class CatalogoValorLogic
    {
        CatalogoValorPersistance catalogoValor = new CatalogoValorPersistance();
        public List<entidades.CatalogoValor> Seleccionar(int id)
        {
            var datos = catalogoValor.SeleccionarPorId(id);
            datos.Add( new CatalogoValor{ IdTipo = "-1", Nombre="[SELECCIONE]"});
            return datos;
        }
    }
}
