using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using entidades = BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
namespace BIT.UDLA.FLUJOS.PASANTIAS.Logic
{
    public class CarreraLogic
    {
        CarreraPersistance carreraValor = new CarreraPersistance();
        public List<entidades.Carrera> SeleccionarListaCarreras()
        {
            var data =carreraValor.SeleccionarListaCarrera();
            data.Add(new Carrera{ ID=-1 , Nombre="[SELECCIONE]"});
            return data;
        }
    }
}
