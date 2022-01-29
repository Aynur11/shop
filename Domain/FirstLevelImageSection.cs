using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    /// <summary>
    /// Категория первого уровня с картинками.
    /// </summary>
    public class FirstLevelImageSection : Entity<int>
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }

        public int FirstLevelIconSectionId { get; set; }
        //[ForeignKey(nameof(FirstLevelIconSectionId))]
        public FirstLevelIconSection FirstLevelIconSection { get; set; }
        public SecondLevelSection SecondLevelSection { get; set; }
    }
}