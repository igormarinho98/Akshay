namespace Akshay.Models
{
    public class Investidor
    {
        protected Investidor() { }

        public Investidor(string nome, string sobrenome, string cpf, string endereco, string cidade, string estado, string cep, string telefone, string email, string dataNascimento, int suitability)
        {
            
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            Endereco = endereco;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            Telefone = telefone;
            Email = email;
            DataNascimento = dataNascimento;
            Suitability = suitability;
        }

        int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public string Cpf { get; set; }

        public string Endereco { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Cep { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string DataNascimento { get; set; }

        public int Suitability { get; set; }



    }
}