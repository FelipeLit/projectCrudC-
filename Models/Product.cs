namespace Proyecto.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Double Price { get; set; }
        public int Amount { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}