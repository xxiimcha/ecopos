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
        private int customerID;
        private string type;
        private int quantity;
        private decimal discount;
        private string note;

        public KeepItem(int terminalID, int productID, string type, int quantity, decimal discount, int customerID)
        {
            this.terminalID = terminalID;
            this.productID = productID;
            this.quantity = quantity;
            this.type = type;
            this.discount = discount;
            this.customerID = customerID;
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
        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public decimal Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        public string Note
        {
            get { return note; }
            set { note = value; }
        }
    }
}
