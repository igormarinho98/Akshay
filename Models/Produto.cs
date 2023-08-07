namespace Akshay.Models
{
    public class Produto
    {
        public Guid Id { get; set; }
        public bool active { get; set; }
        public string description { get; set ; }
        public string name { get; set; }
        public int category_id { get; set;}
        public decimal rentability { get; set;}

    }
}
