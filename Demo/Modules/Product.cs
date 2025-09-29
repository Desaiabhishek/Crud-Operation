using Demo.Modules.Comman;

namespace Demo.Modules
{
    public class Product : Comman_MDL
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
