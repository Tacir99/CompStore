namespace CompStore.Entities
{
    public class Computer
    {
        public int Id { get; set; }
        public string MarkName { get; set; }
        public string ModelName { get; set; }
        public int InStock { get; set; }
        public decimal Price { get; set; }
        public int DetailId { get; set; }
        public Detail Detail { get; set;}
        public ICollection<OrderComputer> OrderComputers { get; set; }

    }
}
