using CSharpFunctionalExtensions;
using System.Collections.Generic;

namespace Domain
{
    /// <summary>
    /// Категория второго уровня.
    /// </summary>
    public class SecondLevelSection : Entity<int>
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public List<Product> Product { get; set; }
        public int FirstLevelImageSectionId { get; set; }

        //[ForeignKey(nameof(FirstLevelImageSectionId))]
        public FirstLevelImageSection FirstLevelImageSection { get; set; }
    }
}