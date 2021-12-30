using CSharpFunctionalExtensions;
using System.Collections.Generic;

namespace Domain
{
    /// <summary>
    /// Категория первого уровня с иконками.
    /// </summary>
    public class FirstLevelIconSection : Entity<int>
    {
        public string Name { get; set; }
        public string IconPath { get; set; }
        public List<FirstLevelImageSection>  FirstLevelImageSections { get; set; }
    }
}   