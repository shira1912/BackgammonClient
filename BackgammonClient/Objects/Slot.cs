using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgammonClient.Objects
{
    internal class Slot
    {
        private int color;
        private int quantity;

        public Slot(int quantity, int color) 
        {
            this.color = color;
            this.quantity = quantity;
        }

        public int getQuantity()
        { 
            return quantity;
        }

        public void setQuantity(int quantity)
        {
            this.quantity = quantity;
        }

        public int getColor() { 
            return color;
        }
        public void setColor(int color)
        {
            this.color = color;
        }

        public string toString()
        {
            return this.color + ":" + this.quantity.ToString();
        }

    }
}
