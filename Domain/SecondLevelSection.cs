namespace Domain
{
    /// <summary>
    /// Категория второго уровня.
    /// </summary>
    public class SecondLevelSection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public Product Product { get; set; }
    }
}