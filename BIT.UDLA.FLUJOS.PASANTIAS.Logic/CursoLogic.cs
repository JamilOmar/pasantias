using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance;
using word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;


namespace BIT.UDLA.FLUJOS.PASANTIAS.Logic
{
    public class CursoLogic
    {
        CursoPersistance cursoPersistance = new CursoPersistance();

        public bool Insertar(Curso item)
        {
            try
            {
                return cursoPersistance.Insertar(item);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }

        public bool Eliminar(Curso item)
        {
            try
            {
                return cursoPersistance.Eliminar(item);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }

        

        public Curso Seleccionar(Curso item)
        {
            try
            {
                return cursoPersistance.Seleccionar(item);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }

         public Curso Actualizar(Curso item)
        {
            try
            {
                return cursoPersistance.Actualizar(item);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }

         public bool ExisteCurso(int idCurso)
         {
             try
             {
                 return cursoPersistance.ExisteCurso(idCurso);
             }
             catch (Exception ex)
             {

                 BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                 throw ex;
             }
         }

         public List<Curso> SeleccionarCursos(int idPersona)
         {

             try
             {
                 return cursoPersistance.SeleccionarCursos(idPersona);
             }
             catch (Exception ex)
             {

                 BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                 throw ex;
             }
         }
    }
}