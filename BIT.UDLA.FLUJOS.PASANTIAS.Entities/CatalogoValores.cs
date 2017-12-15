using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Entities
{
    [Serializable]
    public class CatalogoValor
    {
        public string Nombre { get; set; }
        public int Id { get; set; }
        public string IdTipo { get; set; }
    }
}
