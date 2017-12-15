using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using entidades = BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.MossPersistance;
namespace BIT.UDLA.FLUJOS.PASANTIAS.Logic
{
    public class UsuarioEmpresaLogic
    {

        UsuarioEmpresaPersistance obj = new UsuarioEmpresaPersistance();

        public bool IsValidUser(string username, string password)
        {

            try
            {

                var user = GetUser(username, password);
                if (user == null)
                    return false;
                return user.EsUsuarioInterno ? true : user.EsValido;
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }

        public bool Insertar(UsuarioEmpresa user)
        {

            try
            {
                var aux =GetUser(user.UserName, user.Password);
                var auxEmail = GetUserByEmail(user.Email);
                if (aux == null && auxEmail == null)
                {
                    obj.Insertar(user);
                    return true;
                }
                return false;
              
            }
            catch (Exception ex)
            {
                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }
        public void Actualizar(UsuarioEmpresa user)
        {

            try
            {

                obj.Actualizar(user);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }
        public UsuarioEmpresa GetUser(string username, string password)
        {

            try
            {

                UsuarioEmpresa user =  obj.SeleccionarPorUserNamePassword(username, password);
                if (user == null )
                {
                    user = obj.SeleccionarPorUserNamePasswordEmpresa(username, password);
                }
                return user;
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }
        public UsuarioEmpresa GetUser(string username)
        {

            try
            {

                UsuarioEmpresa user = obj.SeleccionarPorUserName(username);
                if (user == null)
                {
                    user = obj.SeleccionarPorUserNameEmpresa(username);
                }
                return user;
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }
        public UsuarioEmpresa GetUserbyKey(string idaux)
        {
        

            try
            {
                int id = UsuarioEmpresa.DestroyUnique(idaux);
                UsuarioEmpresa user = null;
                if(!UsuarioEmpresa.Interno(idaux))
                    user = obj.SeleccionarPorId(id);
                if (user == null)
                {
                    user = obj.SeleccionarPorIdEmpresa(id);
                }
                return user;
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }
       
        public UsuarioEmpresa GetUserByEmail(string email)
        {

            try
            {

                UsuarioEmpresa user = obj.SeleccionarPorEmail(email);
                if (user == null)
                {
                    user = obj.SeleccionarPorEmailEmpresa(email);
                }
                return user;
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
        }

        public List<UsuarioEmpresa> GetUsersbyEmail(string email, int startRowIndex, int maximumRows,  out int itemsCount)
        {
            try
            {

                return obj.SeleccionarPaginadoPorEmail(email,startRowIndex,maximumRows,out itemsCount);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
       
        }

        public List<UsuarioEmpresa> GetUsersbyEmpresa(int idEmpresa, int startRowIndex, int maximumRows, out int itemsCount)
        {
            try
            {

                return obj.SeleccionarPaginadoPorEmpresa(idEmpresa, startRowIndex, maximumRows, out itemsCount);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }

        }

        public List<UsuarioEmpresa> GetAllUsers(int startRowIndex, int maximumRows, out int itemsCount)
        {
            try
            {

                return obj.SeleccionarPaginado( startRowIndex, maximumRows, out itemsCount);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
           
        }
        public List<UsuarioEmpresa> GetUsersbyUserName(string name, int startRowIndex, int maximumRows,  out int itemsCount)
        {
            try
            {

                return obj.SeleccionarPaginadoPorUserName(name, startRowIndex, maximumRows, out itemsCount);
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            } 
        }

        public List<UsuarioEmpresa> GetAllUsers()
        {
            try
            {

                return obj.SeleccionarTodos();
            }
            catch (Exception ex)
            {

                BIT.UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
                throw ex;
            }
            
        }



       
    }
}
