namespace Akshay.Models
{
    public class Suitability
    {
        protected Suitability () { }

        public Suitability (string perfil, string descricao, string dataRegistro) {
            dataRegistro = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); 
            Perfil = perfil;
            Descricao = descricao;
            DataRegistro = dataRegistro;

           


        }

        int Id { get; set; }
        public string Perfil { get; set; }

        public string Descricao { get; set; }

        public string DataRegistro { get; set; } 


     }
}
