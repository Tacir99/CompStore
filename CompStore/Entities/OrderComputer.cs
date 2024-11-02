namespace CompStore.Entities
{
    public class OrderComputer
    {
        public int Id { get; set; }
        public int OredrId { get; set; }
        public int ComputerId { get; set; }
        public Computer Computer { get; set; }
        public Order Order { get; set; }
    }
}
