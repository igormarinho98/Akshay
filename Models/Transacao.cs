namespace Akshay.Models
{
    public class Transacao
    {

        public Guid Id { get; set; }
        public int investment_id { get; set;}

        public DateTime transaction_date { get; set; }


        public decimal transactiont_amount { get; set; }

        public string transaction_type { get; set; }


        public string description { get; set; }

        public Guid product_id { get; set;}
        public int trader { get; set; }


    }
}
