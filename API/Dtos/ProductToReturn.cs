using Core.Entities;

namespace API.Dtos
{
    public class ProductToReturn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string productType { get; set; }
        public string ProductBrand { get; set; }
    }
}
