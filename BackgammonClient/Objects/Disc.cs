using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonClient.Objects
{
    internal class Disc
    {
        private int slotId;

        public Disc(int slotId) 
        {
            this.slotId = slotId;
        }

        public int getSlotId()
        { 
            return slotId;
        }

        public void setslotId(int slotId) {
            this.slotId = slotId;
        }



    }
}
