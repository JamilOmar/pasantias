using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbNetLink.Data;
using System.Collections.Specialized;
using System.Data;

namespace BIT.UDLA.FLUJOS.PASANTIAS.DbConnector
{
    public   class DBConnectorSwitch:IDisposable
    {
        DbNetLink.Data.DbNetData db;

        public DBConnectorSwitch(Constants.DBConnectionType type)
        {
            var dbobj = DBHelper.GiveDatabaseType(type);
            db = new DbNetLink.Data.DbNetData(dbobj.ConnectionString, dbobj.Provider);
            db.CloseConnectionOnError = false;
            db.Open();
            db.BeginTransaction();
        }

        public DataTable ExecuteQuery(string query, ListDictionary parameters)
        {
            try
            {
                QueryCommandConfig queryCmd = new QueryCommandConfig(query);
                queryCmd.Params = parameters;
                db.ReturnAutoIncrementValue = true;
                var d = db.GetDataTable(queryCmd);
                db.Transaction.Commit();
                return d;
            }
            catch (Exception ex)
            {
                if(db.Conn.State== ConnectionState.Open)
                db.Transaction.Rollback();
                UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
            }
            return null;
        }

        public void ExecuteGenericQuery(string query, ListDictionary parameters)
        {
            try
            {


                QueryCommandConfig queryCmd = new QueryCommandConfig(query);
                queryCmd.Params = parameters;
                db.ExecuteNonQuery(queryCmd);
                db.Transaction.Commit();
            }
            catch (Exception ex)
            {
                if (db.Conn.State == ConnectionState.Open)
                db.Transaction.Rollback();
                UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
            }
        }
        public DataTable GetQuery(string query,string countQuery, ListDictionary parameters, out int aux)
        {
            aux = 0;
            try
            {
                QueryCommandConfig Query = new QueryCommandConfig(countQuery);
                Query.Params = parameters;
                db.ExecuteSingletonQuery(Query); 
                var count = (int?)db.ReaderValue(0);
                if (count.HasValue)
                    aux = count.Value;
                QueryCommandConfig queryCmd = new QueryCommandConfig(query);
                queryCmd.Params = parameters;
                db.ReturnAutoIncrementValue = true;

              
                var d =  db.GetDataTable(queryCmd);
                db.Transaction.Commit();
                return d;
            }
            catch (Exception ex)
            {
                if (db.Conn.State == ConnectionState.Open)
                db.Transaction.Rollback();
                UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
            }
            return null;
        }
        public object GetSingleQuery(string query, ListDictionary parameters)
        {


            try
            {
                QueryCommandConfig Query = new QueryCommandConfig(query);
                Query.Params = parameters;
                db.ExecuteSingletonQuery(Query);
                return db.ReaderValue(0);

                db.Transaction.Commit();

            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
            }
            return null;
        }
        public long? insertQuery(string query, ListDictionary parameters)
        {
            long? id = 0;
            try
            {
             
                CommandConfig command = new CommandConfig(query);
                command.Params = parameters;
                db.ReturnAutoIncrementValue = true;
                id = db.ExecuteInsert(command);
                db.Transaction.Commit();
                return id;
            }
            catch (Exception ex)
            {
                if (db.Conn.State == ConnectionState.Open)
                db.Transaction.Rollback();
                UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
            }
            return null;
        }

        public long? deleteQuery(string query, ListDictionary parameters)
        {
            long? id = 0;
            try
            {
               
                CommandConfig command = new CommandConfig(query);
                command.Params = parameters;
                id = db.ExecuteDelete(command);
                db.Transaction.Commit();
                return id;
            }
            catch (Exception ex)
            {
                if (db.Conn.State == ConnectionState.Open)
                db.Transaction.Rollback();
                UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
            }
            return null;
        }
        public long? updateQuery(string query, ListDictionary parameters, ListDictionary filterParameters)
        {
            long? id = 0;
            try
            {
                UpdateCommandConfig command = new UpdateCommandConfig(query);
                command.Params = parameters;
                command.FilterParams = filterParameters;
                db.AllowUnqualifiedUpdates = true;
                id = db.ExecuteUpdate(command);
                db.Transaction.Commit();
                return id;
            }
            catch (Exception ex)
            {
                if (db.Conn.State == ConnectionState.Open)
                db.Transaction.Rollback();
                UDLA.FLUJOS.PASANTIAS.Comun.Logger.ExLogger(ex);
            }
            return null;
        }
       
        public void Dispose()
        {
            if (db.Conn.State == ConnectionState.Open)
            db.Close();
            db.Dispose();
        }
    }
}
