using CompStore.Entities;

namespace CompStore.DTO.ComputerDTO
{
    public class AddComputerDTO
    {
        public string MarkName { get; set; }
        public string ModelName { get; set; }
        public decimal Price { get; set; }  
        public int InStock { get; set; }
        public int DetailId { get; set; }
        public IEnumerable<Detail> SizeList { get; set; }
       
      
    }
}
