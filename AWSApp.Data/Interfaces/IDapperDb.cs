using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AWSApp.Data.DBContext;
using Dapper;

namespace AWSApp.Data.Interfaces
{
    public interface IDapperDb : IDisposable
    {
        DbConnection GetDbConnection(DatabaseConnectionName connectionName);
        T Get<T>(string sp, DynamicParameters dynamicParameters, DatabaseConnectionName connectionName = DatabaseConnectionName.SWMasterApp, CommandType commandType = CommandType.StoredProcedure, int commandTimeout = 0);

        List<T> GetAll<T>(string sp, DynamicParameters dynamicParameters, DatabaseConnectionName connectionName = DatabaseConnectionName.SWMasterApp, CommandType commandType = CommandType.StoredProcedure, int commandTimeout = 0);

        T ExecuteGet<T>(string sp, DynamicParameters dynamicParameters, DatabaseConnectionName connectionName = DatabaseConnectionName.SWMasterApp, CommandType commandType = CommandType.StoredProcedure);

        List<T> ExecuteGetAll<T>(string sp, DynamicParameters dynamicParameters, DatabaseConnectionName connectionName = DatabaseConnectionName.SWMasterApp, CommandType commandType = CommandType.StoredProcedure);

        int Execute(string sp, DynamicParameters dynamicParameters, DatabaseConnectionName connectionName = DatabaseConnectionName.SWMasterApp, CommandType commandType = CommandType.StoredProcedure);
        List<dynamic> GetDataSet(string sp, DynamicParameters dynamicParameters, DatabaseConnectionName connectionName = DatabaseConnectionName.SWMasterApp, CommandType commandType = CommandType.StoredProcedure, int commandTimeout = 0);
    }
}
