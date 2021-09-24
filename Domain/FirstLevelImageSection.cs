namespace Domain
{
    /// <summary>
    /// Категория первого уровня с картинками.
    /// </summary>
    public class FirstLevelImageSection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public SecondLevelSection SecondLevelSection { get; set; }
    }
}