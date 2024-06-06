using Dapper;
using Npgsql;
using System.Data;

namespace Fleet_ManagementWebApplication.Services
{
    public class DbService : IDbService
    {
        private readonly IDbConnection _db;

        public DbService(IConfiguration configuration)
        {
            _db = new NpgsqlConnection(configuration.GetConnectionString("FleetManagementdb"));
        }

        public async Task<T> GetAsync<T>(string command, object parms)
        {
            T result;

            result = (await _db.QueryAsync<T>(command, parms).ConfigureAwait(false)).FirstOrDefault();

            return result;

        }

        public async Task<IEnumerable<T>> GetAll<T>(string command)
        {

            return await _db.QueryAsync<T>(command);
        }

        public async Task<IEnumerable<T>> GetAll<T>(string command, object parms)
        {

            return await _db.QueryAsync<T>(command,parms);
        }

        public async Task<int> EditData(string command, object parms)
        {
            int result;

            result = await _db.ExecuteAsync(command, parms);

            return result;
        }
    }
}
