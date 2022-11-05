using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIFEngine
{
    public class Thing
    {
        private int id; //ID number for Thing
        private string name; // Name
        private string description;   //the look at description of Thing
        private string rdesc; //The room description, inserted into the Description of the current location it is in.

        
         
        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }
        public int ID { get { return id; } set { id = value; } }
        public string RDesc { get { return rdesc; } set { rdesc = value; } }    


        public List<string> Actions = new List<string>();


        public void Parse()
        {

        }
    }
}
