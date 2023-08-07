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
    public class TransacaoController : ControllerBase
    {

        private readonly string _connectionString;


        public TransacaoController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");

        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const string sql = "SELECT * FROM Transactions ORDER BY transaction_date ;";

                var transacoes = await sqlConnection.QueryAsync<Transacao>(sql);

                return Ok(transacoes);


            }

        }
        
        [HttpGet("TransacaoInvest")]
        public async Task<IActionResult> GetTransactionWithInvestor()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const string sql = "SELECT Transactions.id, Transactions.investment_id, Transactions.transaction_date, Transactions.transaction_amount, Transactions.transaction_type, Transactions.trader, Products.name, Products.description, Products.rentability, Products.category_id FROM Transactions INNER JOIN Products ON Products.ID = Transactions.product_id;";
                

                var transacoesT = await sqlConnection.QueryAsync<TransacaoProduto>(sql);

                if (transacoesT != null)
                {
                    Console.WriteLine(transacoesT.ToString());

                }

                return Ok(transacoesT);


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
                const string sql = "SELECT * FROM Transactions WHERE Id = @id";

                var transacao = await sqlConnection.QuerySingleOrDefaultAsync<Transacao>(sql, parameters);

                if (transacao is null)
                {
                    return NotFound();
                }

                return Ok(transacao);


            }



        }

    }
}

