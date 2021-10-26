using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    /// <summary>
    /// Продукт (товар), который в продаже.
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public int Article { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public FirstLevelImageSection FirstLevelImageSection { get; set; }
        public int SecondLevelSectionId { get; set; }
        [ForeignKey(nameof(SecondLevelSectionId))]
        public int QuantityInStock { get; set; }
        public SecondLevelSection SecondLevelSection { get; set; }
    }
}
