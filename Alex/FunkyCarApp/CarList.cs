using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunkyCarApp
{
    public class CarList
    {
        public string Name { get; set; } = "";
        public List<Car> Cars { get; set; } = new List<Car>();

        public CarList(string name)
        {
            Name = name;
        }
    }
}
