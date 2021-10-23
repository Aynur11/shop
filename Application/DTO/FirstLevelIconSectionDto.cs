using Domain;

namespace Application.DTO
{
    /// <summary>
    /// Категория первого уровня с иконками.
    /// </summary>
    public class FirstLevelIconSectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
        public FirstLevelImageSection FirstLevelImageSection { get; set; }
    }
}
