namespace StoreManagement.Domain.Model
{
    public class Basqet : EntityBase
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public bool Active { get; set; }
    }
}
