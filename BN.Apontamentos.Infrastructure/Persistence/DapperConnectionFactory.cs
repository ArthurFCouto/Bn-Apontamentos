using BN.Apontamentos.Infrastructure.Connection;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace BN.Apontamentos.Infrastructure.Persistence
{
    public interface IDapperConnectionFactory
    {
        IDbConnection CreateConnection();
    }

    public class DapperConnectionFactory : IDapperConnectionFactory
    {
        private readonly DatabaseSettings databaseSettings;

        public DapperConnectionFactory(IOptions<DatabaseSettings> options)
        {
            this.databaseSettings = options.Value;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(databaseSettings.ConnectionString);
        }
    }
}
