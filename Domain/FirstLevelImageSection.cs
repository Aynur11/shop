using CSharpFunctionalExtensions;

namespace Domain
{
    /// <summary>
    /// Категория первого уровня с картинками.
    /// </summary>
    public class FirstLevelImageSection : Entity<int>
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public SecondLevelSection SecondLevelSection { get; set; }
    }
}