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

        [HttpPost]
        public IActionResult AddSuitability(Suitability suitability)
        {
            suitabilityList.Add(suitability);
            return CreatedAtAction(nameof(GetAll), null);
        }


    }