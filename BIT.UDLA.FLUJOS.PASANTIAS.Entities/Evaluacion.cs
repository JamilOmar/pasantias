using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Entities
{
    public class Evaluacion
    {
        public int Id { get; set; }
        public int IdMateria { get; set; }
        public double Nota { get; set; }
        public double NumeroHoras { get; set; }
    }
}
