using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Entities
{
    [Serializable]
    public class Empresa
    {
        public int Id { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public string RepresentanteLegal { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}