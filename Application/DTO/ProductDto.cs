using Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.DTO
{
    /// <summary>
    /// Продукт (товар), который в продаже.
    /// </summary>
    public class ProductDto
    {
        public int Id { get; set; }
        public int Article { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
