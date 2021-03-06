namespace Application.DTO
{
    /// <summary>
    /// Продукт (товар), который в продаже.
    /// </summary>
    public class ProductDto
    {
        public int Article { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int SecondLevelSectionId { get; set; }
        public int QuantityInStock { get; set; }
    }
}
