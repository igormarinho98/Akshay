namespace Akshay.Controllers;

using Akshay.Models;
using Dapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Threading.Tasks;


[Route("[controller]")]
[ApiController]
[EnableCors("AllowSpecificOrigin")]
public class InvestidorController : ControllerBase
{
    private readonly string _connectionString;

    public InvestidorController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Default");


     }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            const string sql = "SELECT * FROM Investidor;";

            var investidores = await sqlConnection.QueryAsync<Investidor>(sql);

            return Ok(investidores);

            
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
            const string sql = "SELECT * FROM Investidor WHERE Id = @id";

            var investidor = await sqlConnection.QuerySingleOrDefaultAsync<Investidor>(sql, parameters);

            if (investidor is null)
            {
                return NotFound();
            }

            return Ok(investidor);


        }



    }


    [HttpPost]
    public async Task<IActionResult> AddInvestidor(Investidor model)
    {
        var investidor = new Investidor(model.Nome, model.Sobrenome, model.Cpf, model.Endereco, model.Cidade, model.Estado, model.Cep, model.Telefone, model.Email, model.DataNascimento, model.Suitability);
        var parameters = new
        {
            investidor.Nome,
            investidor.Sobrenome,
            investidor.Cpf,
            investidor.Endereco,
            investidor.Cidade,
            investidor.Estado,
            investidor.Cep,
            investidor.Telefone,
            investidor.Email,
            investidor.DataNascimento,
            investidor.Suitability


        };

        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            const string sql = "INSERT INTO Investidor OUTPUT Inserted.Id VALUES (@Nome, @Sobrenome, @Cpf, @Endereco, @Cidade, @Estado, @Cep, @Telefone, @Email, @DataNascimento, @Suitability)";

            var id = await sqlConnection.ExecuteScalarAsync<int>(sql, parameters);

            return Ok(id);
        }

    }








}