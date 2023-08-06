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
    public class ProductController : ControllerBase
    {
        private readonly string _connectionString;


        public ProductController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const string sql = "SELECT * FROM Products;";

                var products = await sqlConnection.QueryAsync<Product>(sql);

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

                var product = await sqlConnection.QuerySingleOrDefaultAsync<Product>(sql, parameters);

                if (product is null)
                {
                    return NotFound();
                }

                return Ok(product);


            }



        }

    }
}
