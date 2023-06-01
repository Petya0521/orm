using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsOrm10.Model
{
    public class Fruit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TypeId { get; set; }
        public double Price { get; set; }


        public int FruitTypeId { get; set; }
        public FruitType FruitTypes { get; set; }
    }
}
