using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIFEngine
{
    public class Thing
    {
        private int id;
        private string name;
        private string description;

        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }
        public int ID { get { return id; } set { id = value; } }
    }
}
