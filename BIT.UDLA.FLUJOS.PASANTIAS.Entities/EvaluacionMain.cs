using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Entities
{
   
    [Serializable]
    public class EvaluacionMain
    {
        public int IdPasantia { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        public List<string> Opciones { get; set; }
        public bool EvaluacionEmpresa { get; set; }
        public bool EvaluacionPersonal { get; set; }
    }
}
