﻿namespace Application.DTO
{
    /// <summary>
    /// Категория второго уровня.
    /// </summary>
    public class SecondLevelSectionDto
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int FirstLevelImageSectionId { get; set; }
        //public Product Product { get; set; }
    }
}
