namespace Application.DTO.UpdateEntity
{
    /// <summary>
    /// Категория второго уровня.
    /// </summary>
    public class UpdateSecondLevelSectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int FirstLevelImageSectionId { get; set; }
    }
}
