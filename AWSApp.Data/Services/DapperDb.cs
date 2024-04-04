using AWSApp.Data.DBContext;
using AWSApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace AWSApp.Data.Services
{
    public class DapperDb : IDapperDb
    {
        private readonly IDictionary<DatabaseConnectionName, string> _connectionDict;

        public DapperDb(IDictionary<DatabaseConnectionName, string> connectionDict)
        {
            _connectionDict = connectionDict;
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public T Get<T>(string sp, DynamicParameters dynamicParameters, DatabaseConnectionName connectionName = DatabaseConnectionName.SWMasterApp, CommandType commandType = CommandType.StoredProcedure, int commandTimeout = 0)
        {
            using (IDbConnection con = GetDbConnection(connectionName))
            {
                con.Open();
                using (IDbCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = sp;
                    cmd.CommandType = commandType;
                    cmd.CommandTimeout = commandTimeout;

                    if (dynamicParameters != null)
                    {
                        foreach (var parameter in dynamicParameters.ParameterNames)
                        {
                            var dbParameter = cmd.CreateParameter();
                            dbParameter.ParameterName = parameter;
                            dbParameter.Value = dynamicParameters.Get<object>(parameter);
                            cmd.Parameters.Add(dbParameter);
                        }
                    }

                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Assuming T is a primitive type or a type with a single constructor taking all the fields from the query result
                            return (T)reader.GetValue(0); // Modify this line according to your needs
                        }
                        else
                        {
                            return default(T);
                        }
                    }
                }
            }
        }

        public List<T> GetAll<T>(string sp, DynamicParameters dynamicParameters, DatabaseConnectionName connectionName = DatabaseConnectionName.SWMasterApp, CommandType commandType = CommandType.StoredProcedure, int commandTimeout = 0)
        {
            using (IDbConnection con = GetDbConnection(connectionName))
            {
                //con.Open();
                return con.Query<T>(sp, dynamicParameters, commandType: commandType, commandTimeout: commandTimeout).ToList();
            }
        }

        public T ExecuteGet<T>(string sp, DynamicParameters dynamicParameters, DatabaseConnectionName connectionName = DatabaseConnectionName.SWMasterApp, CommandType commandType = CommandType.StoredProcedure)
        {

            using (IDbConnection con = GetDbConnection(connectionName))
            {
                //con.Open();
                return con.Query<T>(sp, dynamicParameters, commandType: commandType).FirstOrDefault();
            }

        }

        public List<T> ExecuteGetAll<T>(string sp, DynamicParameters dynamicParameters, DatabaseConnectionName connectionName = DatabaseConnectionName.SWMasterApp, CommandType commandType = CommandType.StoredProcedure)
        {

            using (IDbConnection con = GetDbConnection(connectionName))
            {
                //con.Open();
                return con.Query<T>(sp, dynamicParameters, commandType: commandType).ToList();
            }

        }

        public int Execute(string sp, DynamicParameters dynamicParameters, DatabaseConnectionName connectionName = DatabaseConnectionName.SWMasterApp, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection con = GetDbConnection(connectionName))
            {
                //con.Open();
                return con.Execute(sp, dynamicParameters, commandType: commandType);
            }
        }

        public DbConnection GetDbConnection(DatabaseConnectionName connectionName)
        {
            //return new SqlConnection(_config.GetConnectionString(Connectionstring));

            //return new SqlConnection(_connectionString.Value);

            string connectionString = null;
            if (_connectionDict.TryGetValue(connectionName, out connectionString))
            {
                return new SqlConnection(connectionString);
            }

            throw new ArgumentNullException();
        }

        public List<dynamic> GetDataSet(string sp, DynamicParameters dynamicParameters, DatabaseConnectionName connectionName = DatabaseConnectionName.SWMasterApp, CommandType commandType = CommandType.StoredProcedure, int commandTimeout = 0)
        {
            using (IDbConnection con = GetDbConnection(connectionName))
            {
                List<dynamic> data = new List<dynamic>();
                using (var multi = con.QueryMultiple(sp, dynamicParameters, commandType: commandType, commandTimeout: commandTimeout))
                {
                    while (!multi.IsConsumed)//<-- query multiple until consumed
                    {
                        var list = multi.Read<dynamic>().ToList();
                        data.Add(list);
                    }
                }
                return data;
            }
        }

       
    }
}
