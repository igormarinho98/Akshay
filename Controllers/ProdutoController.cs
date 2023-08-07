using Akshay.Models;
using Dapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Akshay.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class ProdutoController : ControllerBase
    {
        private readonly string _connectionString;


        public ProdutoController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const string sql = "SELECT * FROM Products;";

                var products = await sqlConnection.QueryAsync<Produto>(sql);

                return Ok(products);


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
                const string sql = "SELECT * FROM Products WHERE Id = @id";

                var product = await sqlConnection.QuerySingleOrDefaultAsync<Produto>(sql, parameters);

                if (product is null)
                {
                    return NotFound();
                }

                return Ok(product);


            }



        }

    }
}
