using CSharpFunctionalExtensions;
using System.Collections.Generic;

namespace Domain
{
    /// <summary>
    /// Категория второго уровня.
    /// </summary>
    public class SecondLevelSection : Entity<int>
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public Product Product { get; set; }
    }
}