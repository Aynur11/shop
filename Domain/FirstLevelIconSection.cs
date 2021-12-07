using CSharpFunctionalExtensions;

namespace Domain
{
    /// <summary>
    /// Категория первого уровня с иконками.
    /// </summary>
    public class FirstLevelIconSection : Entity<int>
    {
        public string Name { get; set; }
        public string IconPath { get; set; }
        public FirstLevelImageSection FirstLevelImageSection { get; set; }
    }
}