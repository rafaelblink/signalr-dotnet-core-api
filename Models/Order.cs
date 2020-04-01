namespace TestHubWebApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string TableNumber { get; set; }
        public string Customer { get; set; }
        public string Item { get; set; }
        public string Extras { get; set; }
    }
}