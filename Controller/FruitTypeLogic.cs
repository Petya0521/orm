using FruitsOrm10.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsOrm10.Controller
{
    public class FruitTypeLogic
    {
        private FruitContext _fruitContext = new FruitContext(); 

       
        public List<FruitType> GetAllFruitTypes()
        {
            return _fruitContext.FruitTypes.ToList();
        }
        public string GetFruitTypeById(int id)
        {
            return _fruitContext.FruitTypes.Find(id).NameType;
        }
    }
}
