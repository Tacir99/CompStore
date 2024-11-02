namespace CompStore.Entities
{
    public class Detail
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public ICollection<Computer> Computers { get; set; }

    }
}
