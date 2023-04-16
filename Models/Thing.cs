using CSIFEngine.ViewModels;
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
        private string? name; // Name
        private string? description;   //the look at description of Thing
        private string? rdesc; //The room description, inserted into the Description of the current location it is in.
        private string? edesc; //The description displayed when this Item is equiped or wore with ('wear' or 'equip')
        private bool isFixed; //Is this fixed in place or movable.
        private bool wearable; //Is this a wearable item? 
        private bool listener; //Should player commands be passed to this for parsing?

        public event EventHandler<PlayerTurnsEventArgs> PlayerTurnsAdjustment;

        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }
        public int ID { get { return id; } set { id = value; } }
        public string RDesc { get { return rdesc; } set { rdesc = value; } }
        public string EDesc { get { return edesc; } set { edesc = value; } }
        public bool Fixed { get { return isFixed; } set { isFixed = value; } }
        public bool Wearable { get { return wearable; } set { wearable = value; } } 
        public bool Listener { get { return listener; } set { listener = value; } }

        public List<string> Actions = new List<string>();


        public virtual void Parse(string[] words)
        {
            string command = words[0];
        }

        protected virtual void OnPlayerTurnsAdjustment(int turnsAdjustment)
        {
            PlayerTurnsAdjustment?.Invoke(this, new PlayerTurnsEventArgs(turnsAdjustment));
        }


    }
}
