using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using entidades = BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
namespace BIT.UDLA.FLUJOS.PASANTIAS.Logic
{
    public class EmpresaLogic
    {
        EmpresaPersistance empresa = new EmpresaPersistance();
        #region CRUD
        public bool Insertar(entidades.Empresa item, out long? idEmpresa)
        {
            try
            {

                return empresa.Insertar(item, out idEmpresa);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }

       

        public bool Eliminar(entidades.Empresa item)
        {
            try
            {
                return empresa.Eliminar(item);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }

        #endregion

        #region Queries
        public entidades.Empresa Seleccionar(entidades.Empresa item)
        {
            try
            {
                return empresa.Seleccionar(item);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }

        #endregion

        #region Custom Methods
        public entidades.Empresa SeleccionarPorId(int id)
        {
            try
            {
                return empresa.SeleccionarPorId(id);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }

        #endregion





        public List<Empresa> SeleccionarListaEmpresas(string razon,int itemsPorPagina, int numeroPagina, out int aux)
        {
            try
            {
                return empresa.SeleccionarListaEmpresas(razon,itemsPorPagina, numeroPagina, out aux);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }
    }
}
