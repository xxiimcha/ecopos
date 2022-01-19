using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoPOSv2
{
    class KeepItem
    {
        private int holdID;
        private int terminalID;
        private int productID;
        private int quantity;
        private string note;

        public KeepItem(int terminalID, int productID, int quantity)
        {
            this.terminalID = terminalID;
            this.productID = productID;
            this.quantity = quantity;
        }

        public int HoldID
        {
            get { return holdID; }
            set { holdID = value; }
        }
        public int TerminalID
        {
            get { return terminalID; }
            set { terminalID = value; }
        }
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public string Note
        {
            get { return note; }
            set { note = value; }
        }
    }
}
