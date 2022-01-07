using EcoPOSControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoPOSv2
{
    public static class GlobalVariables
    {
        public static DataTable dtPurchaseProducts;

        public static void LoadPurchaseProducts()
        {
            SQLControl privateSQL = new SQLControl();

            privateSQL.Query(@"SELECT p.productID, p.description as 'Name', c.name as 'Category', 
                       i.stock_qty as 'Stock',p.cost FROM products as p
                       INNER JOIN inventory as i 
                       ON p.productID = i.productID
                       INNER JOIN product_category as c 
                       ON p.categoryID = c.categoryID 
                       WHERE c.categoryID NOT IN (99999999999) ORDER BY p.description ASC");

            if (privateSQL.HasException(true))
                return;

            dtPurchaseProducts = privateSQL.DBDT;
        }
    }
}
