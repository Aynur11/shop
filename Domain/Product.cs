using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        public int Id { get; set; }
        public int Article { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public FirstLevelImageSection FirstLevelImageSection { get; set; }
        public SecondLevelSection SecondLevelSection { get; set; }
    }
}
