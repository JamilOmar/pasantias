using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Entities
{
    [Serializable]
    public class Supervisor
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string Nombres { get; set; }
        public string Area { get; set; }
        public string  Telefono { get; set; }
        public string Email { get; set; }
    }
}
