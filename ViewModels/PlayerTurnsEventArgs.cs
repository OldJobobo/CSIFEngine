using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIFEngine.ViewModels
{
    public class PlayerTurnsEventArgs : EventArgs
    {
        public int TurnsAdjustment { get; set; }

        public PlayerTurnsEventArgs(int turnsAdjustment)
        {
            TurnsAdjustment = turnsAdjustment;
        }
    }

}
