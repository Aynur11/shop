﻿using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    /// <summary>
    /// Продукт (товар), который в продаже.
    /// </summary>
    public class Product : Entity<int>
    {
        public int Article { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }

        //public int FirstLevelIconSectionId { get; set; }
        //[ForeignKey(nameof(FirstLevelIconSectionId))]
        //public FirstLevelIconSection FirstLevelIconSection { get; set; }

        //public int FirstLevelImageSectionId { get; set; }
        //[ForeignKey(nameof(FirstLevelImageSectionId))]
        //public FirstLevelImageSection FirstLevelImageSection { get; set; }

        public int SecondLevelSectionId { get; set; }
        [ForeignKey(nameof(SecondLevelSectionId))]
        public SecondLevelSection SecondLevelSection { get; set; }

        public ProductQuantity QuantityInStock { get; set; }
    }
}
