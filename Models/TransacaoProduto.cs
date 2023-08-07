namespace Akshay.Models
{
    public class TransacaoProduto
    {

        public Guid Id { get; set; }
        public int investment_id { get; set; }

        public DateTime transaction_date { get; set; }


        public decimal transaction_amount { get; set; }

        public string transaction_type { get; set; }



        public int trader { get; set; }

        public string name { get; set; }

        public string description { get; set; }
        public decimal rentability { get; set; }
        public int category_id { get; set; }


    }
}
