using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.Comun;

namespace BIT.UDLA.FLUJOS.PASANTIAS.ProcesoLote
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Debug");
            //Console.ReadLine();
            Logger.InfoLogger("Batch Process started at " + DateTime.Now.ToString());
            EjecutarProceso();
            Logger.InfoLogger("Batch Process ended at " + DateTime.Now.ToString());
        }

        private static void EjecutarProceso()
        {
            try
            {
                PasantiasPreprofesionalesLogic obj = new PasantiasPreprofesionalesLogic();
                List<PasantiasPreProfesionales> pasantias = obj.SeleccionarPasantiasActivas();

                if (pasantias == null)
                    return;

                UsuarioLogic uobj = new UsuarioLogic();
                string mensaje = "";

                foreach (PasantiasPreProfesionales pasantia in pasantias)
                {
                    try
                    {
                        User usr = uobj.ObtenerDatos(pasantia.Matricula, out mensaje);

                        if (usr == null)
                        {
                            Logger.InfoLogger(string.Format("Processed: {0} ; {1}", pasantia.Matricula, "Sin usuario", mensaje));
                            pasantia.ProblemaEnElSistemaSAES = true;
                            obj.Actualizar(pasantia);
                            continue;
                        }

                        if (!uobj.AlumnoEsValido(usr, out mensaje))
                        {
                            Logger.InfoLogger(string.Format("Processed: {0} ; {1}", pasantia.Matricula, "Cancelado", mensaje));
                            pasantia.ProblemaEnElSistemaSAES = true;
                            obj.Actualizar(pasantia);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.InfoLogger(string.Format("Processed: {0} ; {1}", pasantia.Matricula, "Error", ex.Message));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }
    }
}
