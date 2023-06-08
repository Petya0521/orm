using FruitsOrm10.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsOrm10.Controller
{
    public class FruitLogic
    {
        private FruitContext _fruitContext = new FruitContext();
        public Fruit Get(int id)
        {
            Fruit findedFruit = _fruitContext.Fruits.Find(id);
            if (findedFruit != null)
            {
                _fruitContext.Entry(findedFruit).Reference(x => x.FruitTypes).Load();
            }
            return findedFruit;
        }
        public List<Fruit> GetAll()
        {
            return _fruitContext.Fruits.Include("FruitTypes").ToList();
        }
        public void Create(Fruit fruit)
        {
            _fruitContext.Fruits.Add(fruit);
            _fruitContext.SaveChanges();
        }
        public void Update(int id, Fruit fruit)
        {
            Fruit findedFruit = _fruitContext.Fruits.Find(id); if (findedFruit == null) 
            {
                return;
            }
            findedFruit.Name = fruit.Name;
            findedFruit.Description = fruit.Description;
            findedFruit.TypeId = fruit.TypeId;
            findedFruit.Price = fruit.Price;
            findedFruit.FruitTypes = fruit.FruitTypes;
            _fruitContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Fruit findedDog = _fruitContext.Fruits.Find(id);
            _fruitContext.Fruits.Remove(findedDog);
            _fruitContext.SaveChanges();
        }
    }
}
