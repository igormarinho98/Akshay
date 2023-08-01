namespace Akshay.Controllers;

using Akshay.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Threading.Tasks;


        [Route("[controller]")]
        [ApiController]
        public class SuitabilityController : ControllerBase
        {
            private readonly string _connectionString;            

            public SuitabilityController(IConfiguration configuration) 
            {
                _connectionString = configuration.GetConnectionString("Default");

    
            }
    
            private static List<Suitability> suitabilityList = new List<Suitability>();


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            using (var sqlConnection = new SqlConnection(_connectionString)) 
            {
                const string sql = "SELECT * FROM Suitability ORDER BY PERFIL ASC;";

                var suitabilities = await sqlConnection.QueryAsync<Suitability>(sql);

                return Ok(suitabilities);
            
            }
             
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var parameters = new
            {
            id
            };
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const string sql = "SELECT * FROM Suitability WHERE Id = @id";
                
                var suitability = await sqlConnection.QuerySingleOrDefaultAsync<Suitability> (sql, parameters);

                if (suitability is null)
                {
                    return NotFound();
                }

                return Ok(suitability);
        
        
            }
    
    
    
        }


        [HttpPost]
        public async Task<IActionResult> AddSuitability(Suitability model)
        {
            var suitability = new Suitability(model.Perfil, model.Descricao, model.DataRegistro);
            var parameters = new
            {
                suitability.Perfil,
                suitability.Descricao,
                suitability.DataRegistro

     
            };

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const string sql = "INSERT INTO Suitability OUTPUT Inserted.Id VALUES (@Perfil, @Descricao, @DataRegistro)";

                var id = await sqlConnection.ExecuteScalarAsync<int>(sql, parameters);

              return Ok(id);
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Suitability model)
        {

            var parameters = new
            {
                id,
                model.Descricao,
            };
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const string sql = "UPDATE Suitability SET Descricao = @Descricao WHERE Id = @id";

                await sqlConnection.ExecuteAsync(sql, parameters);


              
                return NoContent();

            }

        }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {

        var parameters = new
        {
            id,
        };
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            const string sql = "DELETE FROM Suitability WHERE Id = @id";

            await sqlConnection.ExecuteAsync(sql, parameters);



            return NoContent();

        }

    }

}