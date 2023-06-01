using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace FruitsOrm10.Model
{
        public class FruitContext : DbContext
        {
            public FruitContext() : base("FruitContext")
            {

            }
            public DbSet<Fruit> Fruits { get; set; }
            public DbSet<FruitType> FruitTypes { get; set; }
    }
}
