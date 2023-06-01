using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsOrm10.Model
{
    public class FruitType
    {
        public int Id { get; set; }
        public string NameType { get; set; }

        public ICollection<Fruit> Fruits { get; set; }
    }
}
