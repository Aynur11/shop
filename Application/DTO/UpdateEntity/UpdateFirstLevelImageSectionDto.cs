namespace Application.DTO.UpdateEntity
{
    /// <summary>
    /// Категория первого уровня с картинками.
    /// </summary>
    public class UpdateFirstLevelImageSectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int FirstLevelIconSectionId { get; set; }
    }
}
