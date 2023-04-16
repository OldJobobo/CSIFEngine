using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIFEngine
{
    [Serializable]
    public class GameState
    {
        public List<Room> Rooms { get; set; }
        public Player Player { get; set; }

        public GameState(List<Room> rooms, Player player)
        {
            Rooms = rooms;
            Player = player;
        }
    }
}
