using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using db = BIT.UDLA.FLUJOS.PASANTIAS.DbConnector;
using queries = BIT.UDLA.FLUJOS.PASANTIAS.Constants;
using System.Collections.Specialized;
using BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance.Properties;
using BIT.UDLA.FLUJOS.PASANTIAS.Comun;
using System.Data;

namespace BIT.UDLA.FLUJOS.PASANTIAS.DBPersistance
{
    public class UsuarioEmpresaPersistance
    {
        public void Insertar(UsuarioEmpresa item)
        {
            using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
            {
                ListDictionary itemListDictionary = new ListDictionary();
                itemListDictionary.Add("emp_id", item.empId);
                itemListDictionary.Add("UserName", item.UserName);
                itemListDictionary.Add("Nombre", item.Nombre);
                itemListDictionary.Add("Apellido", item.Apellido);
                itemListDictionary.Add("Password", item.Password);
                itemListDictionary.Add("Telefono", item.Telefono);
                itemListDictionary.Add("Email", item.Email);
                itemListDictionary.Add("Activo", item.EsValido);
                obj.ExecuteGenericQuery(Queries.Default.InsertarUsuarioEmpresa, itemListDictionary);
               
            }
        }

        public void Actualizar(UsuarioEmpresa item)
        {
            using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
            {
                ListDictionary itemListDictionary = new ListDictionary();
                itemListDictionary.Add("id", item.Id);
                itemListDictionary.Add("UserName", item.UserName);
                itemListDictionary.Add("Nombre", item.Nombre);
                itemListDictionary.Add("Apellido", item.Apellido);
                itemListDictionary.Add("Password", item.Password);
                itemListDictionary.Add("Telefono", item.Telefono);
                itemListDictionary.Add("Email", item.Email);
                itemListDictionary.Add("Activo", item.EsValido);
                obj.ExecuteGenericQuery(Queries.Default.ActualizarUsuarioEmpresa, itemListDictionary);
               
            }
        }

     

     

        public UsuarioEmpresa SeleccionarPorEmail(string email)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("Email", email);

                    DataRow query = (from empresa in obj.ExecuteQuery(Queries.Default.ObtenerUsuarioPorEmail, itemListDictionary).AsEnumerable()
                                     select empresa).FirstOrDefault();

                    if (query != null)
                    {
                        return MappeoOrigen(query);
                    }
                }
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
            }
            return null;
        }
        public UsuarioEmpresa SeleccionarPorEmailEmpresa(string email)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("Email", email);

                    DataRow query = (from empresa in obj.ExecuteQuery(Queries.Default.ObtenerUsuarioPorEmailEmpresa, itemListDictionary).AsEnumerable()
                                     select empresa).FirstOrDefault();

                    if (query != null)
                    {
                        return MappeoOrigen(query);
                    }
                }
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
            }
            return null;
        }
        public UsuarioEmpresa SeleccionarPorUserName(string username)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("UserName", username);

                    DataRow query = (from empresa in obj.ExecuteQuery(Queries.Default.ObtenerUsuarioPorUserName, itemListDictionary).AsEnumerable()
                                     select empresa).FirstOrDefault();

                    if (query != null)
                    {
                        return MappeoOrigen(query);
                    }
                }
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
            }
            return null;
        }
        public UsuarioEmpresa SeleccionarPorUserNameEmpresa(string username)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("UserName", username);

                    DataRow query = (from empresa in obj.ExecuteQuery(Queries.Default.ObtenerUsuarioPorUserNameEmpresa, itemListDictionary).AsEnumerable()
                                     select empresa).FirstOrDefault();

                    if (query != null)
                    {
                        return MappeoOrigen(query);
                    }
                }
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
            }
            return null;
        }
        public UsuarioEmpresa SeleccionarPorUserNamePassword(string username,string password)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("UserName", username);
                    itemListDictionary.Add("Password", password);

                    DataRow query = (from empresa in obj.ExecuteQuery(Queries.Default.ObtenerUsuarioPorUserNamePassword, itemListDictionary).AsEnumerable()
                                     select empresa).FirstOrDefault();

                    if (query != null)
                    {
                        return MappeoOrigen(query);
                    }
                }
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
            }
            return null;
        }
        public UsuarioEmpresa SeleccionarPorUserNamePasswordEmpresa(string username, string password)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("UserName", username);
                    itemListDictionary.Add("Password", password);

                    DataRow query = (from empresa in obj.ExecuteQuery(Queries.Default.ObtenerUsuarioPorUserNamePasswordEmpresa, itemListDictionary).AsEnumerable()
                                     select empresa).FirstOrDefault();

                    if (query != null)
                    {
                        return MappeoOrigen(query);
                    }
                }
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
            }
            return null;
        }
        public UsuarioEmpresa SeleccionarPorId(int id)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("Id", id);

                    DataRow query = (from empresa in obj.ExecuteQuery(Queries.Default.ObtenerUsuarioPorID, itemListDictionary).AsEnumerable()
                                     select empresa).FirstOrDefault();

                    if (query != null)
                    {
                        return MappeoOrigen(query);
                    }
                }
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
            }
            return null;
        }
        public UsuarioEmpresa SeleccionarPorIdEmpresa(int id)
        {
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("Id", id);

                    DataRow query = (from empresa in obj.ExecuteQuery(Queries.Default.ObtenerUsuarioEmpresasPorID, itemListDictionary).AsEnumerable()
                                     select empresa).FirstOrDefault();

                    if (query != null)
                    {
                        return MappeoOrigen(query);
                    }
                }
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
            }
            return null;
        }
        public List<UsuarioEmpresa> SeleccionarPaginado( int RowIndex, int numberofPage, out int maxItems)
        {
            List<UsuarioEmpresa> usuarios = new List<UsuarioEmpresa>();
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    maxItems = 0;
                    ListDictionary itemListDictionary = new ListDictionary();
                  
                    itemListDictionary.Add("Offset", RowIndex);
                    itemListDictionary.Add("Limit", numberofPage);
                    itemListDictionary.Add("MaxItems", maxItems);

                    DataTable query = obj.GetQuery(Queries.Default.ObtenerTodosLosUsuariosPaginados, Queries.Default.ObtenerTodosLosUsuariosPaginadosCount, itemListDictionary, out maxItems);

                    if (query != null)
                    {
                        foreach (DataRow item in query.Rows)
                        {
                            usuarios.Add(MappeoOrigen(item));
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
                throw ex;
            }
            return usuarios;
        }
        public List<UsuarioEmpresa> SeleccionarTodos()
        {
            List<UsuarioEmpresa> usuarios = new List<UsuarioEmpresa>();
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                
                    ListDictionary itemListDictionary = new ListDictionary();

                   

                    DataTable query = obj.ExecuteQuery(Queries.Default.ObtenerTodosLosUsuarios, itemListDictionary);

                    if (query != null)
                    {
                        foreach (DataRow item in query.Rows)
                        {
                            usuarios.Add(MappeoOrigen(item));
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
                throw ex;
            }
            return usuarios;
        }
        public List<UsuarioEmpresa> SeleccionarPaginadoPorEmail(string email,int RowIndex, int numberofPage, out int maxItems)
        {
            List<UsuarioEmpresa> usuarios = new List<UsuarioEmpresa>();
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    maxItems = 0;
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("Email", email);
                    itemListDictionary.Add("Offset", RowIndex);
                    itemListDictionary.Add("Limit", numberofPage);
                    itemListDictionary.Add("MaxItems", maxItems);

                    DataTable query = obj.GetQuery(Queries.Default.ObtenerTodosLosUsuariosPorEmailPaginados, Queries.Default.ObtenerTodosLosUsuariosPorEmailPaginadosCount, itemListDictionary, out maxItems);

                    if (query != null)
                    {
                        foreach (DataRow item in query.Rows)
                        {
                            usuarios.Add( MappeoOrigen(item));
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
                throw ex;
            }
            return usuarios;
        }
        public List<UsuarioEmpresa> SeleccionarPaginadoPorUserName(string username, int RowIndex, int numberofPage, out int maxItems)
        {
            List<UsuarioEmpresa> usuarios = new List<UsuarioEmpresa>();
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    maxItems = 0;
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("UserName", username);
                    itemListDictionary.Add("Offset", RowIndex);
                    itemListDictionary.Add("Limit", numberofPage);
                    itemListDictionary.Add("MaxItems", maxItems);

                    DataTable query = obj.GetQuery(Queries.Default.ObtenerTodosLosUsuarioPorUsernamePaginados, Queries.Default.ObtenerTodosLosUsuarioPorUsernamePaginadosCount, itemListDictionary, out maxItems);

                    if (query != null)
                    {
                        foreach (DataRow item in query.Rows)
                        {
                            usuarios.Add(MappeoOrigen(item));
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
                throw ex;
            }
            return usuarios;
        }
        public List<UsuarioEmpresa> SeleccionarPaginadoPorEmpresa(int id, int RowIndex, int numberofPage, out int maxItems)
        {
            List<UsuarioEmpresa> usuarios = new List<UsuarioEmpresa>();
            try
            {
                using (db.DBConnectorSwitch obj = new db.DBConnectorSwitch(Constants.DBConnectionType.BEMPLEO))
                {
                    maxItems = 0;
                    ListDictionary itemListDictionary = new ListDictionary();
                    itemListDictionary.Add("EmpId", id);
                    itemListDictionary.Add("Offset", RowIndex);
                    itemListDictionary.Add("Limit", numberofPage);
                    itemListDictionary.Add("MaxItems", maxItems);

                    DataTable query = obj.GetQuery(Queries.Default.ObtenerTodosLosUsuariosPorEmpresasPaginados, Queries.Default.ObtenerTodosLosUsuariosPorEmpresasPaginadosCount, itemListDictionary, out maxItems);

                    if (query != null)
                    {
                        foreach (DataRow item in query.Rows)
                        {
                            usuarios.Add(MappeoOrigen(item));
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                Logger.ExLogger(ex);
                throw ex;
            }
            return usuarios;
        }
        public UsuarioEmpresa MappeoOrigen(DataRow item)
        {
            UsuarioEmpresa usuario = new UsuarioEmpresa();
            
                usuario.Id = (int)item[0];
                 usuario.empId = item.IsNull(1) ? null : (int?)item[1];
                 usuario.UserName = item.IsNull(2) ? string.Empty : item[2].ToString();
                 usuario.Nombre = item.IsNull(3) ? string.Empty : item[3].ToString();
                 usuario.Apellido = item.IsNull(4) ? string.Empty : item[4].ToString();
                 usuario.Password = item.IsNull(5) ? string.Empty : item[5].ToString();
                 usuario.Telefono = item.IsNull(6) ? string.Empty : item[6].ToString();
                 usuario.Email = item.IsNull(7) ? string.Empty : item[7].ToString();
                 usuario.EsValido = item.IsNull(8) ? false : System.Convert.ToBoolean((item[8]));
                 return usuario;
            
        }

    }
}
