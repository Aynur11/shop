using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Категория второго уровня.
    /// </summary>
    public class SecondLevelSection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IamgePath { get; set; }
        public Product Product { get; set; }
    }
}