namespace CompStore.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderCount { get; set; }
        public int OrderNumber { get; set; }
        public DateOnly OrderDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderComputer> OrderComputers { get; set; }
    }
}
