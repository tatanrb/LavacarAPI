using Dapper;
using LavacarAPI.Data;
using LavacarAPI.DTOs;
using LavacarAPI.Models;
using Microsoft.Data.SqlClient;

namespace LavacarAPI.Repositories
{
    public class NivelClienteRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory;

        public NivelClienteRepository (DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<NivelCliente>> ObtenerTodos()
        {
            using var connection = _dbConnectionFactory.CreateConnection();
            var query = "SELECT * FROM NivelClientes";

            return await connection.QueryAsync<NivelCliente>(query);
        }

        public async Task<NivelCliente> ObtenerPorId(int id)
        {
            using var connection = _dbConnectionFactory.CreateConnection();
            var query = "SELECT * FROM NivelClientes WHERE NivelClienteID = @ID";

            return await connection.QueryFirstOrDefaultAsync<NivelCliente>(query, new {ID = id});
        }

        public async Task<NivelCliente> Crear(NivelClienteDTO dto)
        {
            using var connection = _dbConnectionFactory.CreateConnection();
            var query = "INSERT INTO NivelClientes (Nombre, Beneficio) values (@Nombre, @Beneficio)";

            return await connection.QuerySingleOrDefaultAsync<NivelCliente>(query, dto);
        }

        public async Task<bool> Actualizar(NivelClienteDTO dto)
        {
            using var connection = _dbConnectionFactory.CreateConnection();
            var query = "UPDATE NivelClientes SET Nombre = @Nombre, Beneficio = @Beneficio, FechaModificacion = getdate() AT TIME ZONE 'UTC' AT TIME ZONE 'Central Standard Time' WHERE NivelClienteID = @NivelClienteID";

            return await connection.ExecuteAsync(query, dto) > 0;
        }
    }
}
