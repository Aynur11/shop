using Domain;

namespace Application.DTO.UpdateEntity
{
    /// <summary>
    /// Продукт (товар), который в продаже.
    /// </summary>
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public int Article { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int SecondLevelSectionId { get; set; }
        public int QuantityInStock { get; set; }
    }
}
