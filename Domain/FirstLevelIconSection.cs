namespace Domain
{
    /// <summary>
    /// Категория первого уровня с иконками.
    /// </summary>
    public class FirstLevelIconSection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
        public FirstLevelImageSection FirstLevelImageSection { get; set; }
    }
}