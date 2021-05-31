using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using EcoPOSv2;
using Microsoft.VisualBasic;

public class RolePermission
{
    //public void Order(Order frm)
    //{
    //    if (Main.Instance.by_pass_user)
    //    {
    //        if (Main.Instance.bp_ord_payment == false)
    //            frm.btnPayment.Enabled = false;
    //        if (Main.Instance.bp_ord_customer == false)
    //            frm.btnCustomer.Enabled = false;
    //        if (Main.Instance.bp_ord_discount == false)
    //            frm.btnDiscount.Enabled = false;
    //        if (Main.Instance.bp_ord_void_item == false)
    //            frm.btnVoidItem.Enabled = false;
    //        if (Main.Instance.bp_ord_void_transaction == false)
    //            frm.btnVoid.Enabled = false;
    //        if (Main.Instance.bp_ord_cancel_transaction == false)
    //            frm.btnCancel.Enabled = false;
    //        if (Main.Instance.bp_ord_redeem_item == false)
    //            frm.btnRedeem.Enabled = false;

    //        if (Main.Instance.bp_ord_payment == true)
    //            frm.btnPayment.Enabled = true;
    //        if (Main.Instance.bp_ord_customer == true)
    //            frm.btnCustomer.Enabled = true;
    //        if (Main.Instance.bp_ord_discount == true)
    //            frm.btnDiscount.Enabled = true;
    //        if (Main.Instance.bp_ord_void_item == true)
    //            frm.btnVoidItem.Enabled = true;
    //        if (Main.Instance.bp_ord_void_transaction == true)
    //            frm.btnVoid.Enabled = true;
    //        if (Main.Instance.bp_ord_cancel_transaction == true)
    //            frm.btnCancel.Enabled = true;
    //        if (Main.Instance.bp_ord_redeem_item == true)
    //            frm.btnRedeem.Enabled = true;
    //    }
    //    else
    //    {
    //        if (Main.Instance.rp_ord_payment == false)
    //            frm.btnPayment.Enabled = false;
    //        if (Main.Instance.rp_ord_customer == false)
    //            frm.btnCustomer.Enabled = false;
    //        if (Main.Instance.rp_ord_discount == false)
    //            frm.btnDiscount.Enabled = false;
    //        if (Main.Instance.rp_ord_void_item == false)
    //            frm.btnVoidItem.Enabled = false;
    //        if (Main.Instance.rp_ord_void_transaction == false)
    //            frm.btnVoid.Enabled = false;
    //        if (Main.Instance.rp_ord_cancel_transaction == false)
    //            frm.btnCancel.Enabled = false;
    //        if (Main.Instance.rp_ord_redeem_item == false)
    //            frm.btnRedeem.Enabled = false;

    //        if (Main.Instance.rp_ord_payment == true)
    //            frm.btnPayment.Enabled = true;
    //        if (Main.Instance.rp_ord_customer == true)
    //            frm.btnCustomer.Enabled = true;
    //        if (Main.Instance.rp_ord_discount == true)
    //            frm.btnDiscount.Enabled = true;
    //        if (Main.Instance.rp_ord_void_item == true)
    //            frm.btnVoidItem.Enabled = true;
    //        if (Main.Instance.rp_ord_void_transaction == true)
    //            frm.btnVoid.Enabled = true;
    //        if (Main.Instance.rp_ord_cancel_transaction == true)
    //            frm.btnCancel.Enabled = true;
    //        if (Main.Instance.rp_ord_redeem_item == true)
    //            frm.btnRedeem.Enabled = true;
    //    }
    //}

    public void Home(Main frm)
    {
        if (Main.Instance.by_pass_user)
        {
            if (Main.Instance.bp_home_switch_cashier == false)
                frm.btnXReading.Enabled = false;
            if (Main.Instance.bp_home_more == false)
                frm.btnMore.Enabled = false;

            if (Main.Instance.bp_home_switch_cashier == true)
                frm.btnXReading.Enabled = true;
            if (Main.Instance.bp_home_more == true)
                frm.btnMore.Enabled = true;
        }
        else
        {
            if (Main.Instance.rp_home_switch_cashier == false)
                frm.btnXReading.Enabled = false;
            if (Main.Instance.rp_home_more == false)
                frm.btnMore.Enabled = false;

            if (Main.Instance.rp_home_switch_cashier == true)
                frm.btnXReading.Enabled = true;
            if (Main.Instance.rp_home_more == true)
                frm.btnMore.Enabled = true;
        }
    }

    //public void Payment(Payment frm)
    //{
    //    if (Main.Instance.by_pass_user)
    //    {
    //        if (Main.Instance.bp_pay_payment_method == false)
    //            frm.cmbMethod.Enabled = false;
    //        if (Main.Instance.bp_pay_gift_certificate == false)
    //            frm.btnGC.Enabled = false;

    //        if (Main.Instance.bp_pay_payment_method == true)
    //            frm.cmbMethod.Enabled = true;
    //        if (Main.Instance.bp_pay_gift_certificate == true)
    //            frm.btnGC.Enabled = true;
    //    }
    //    else
    //    {
    //        if (Main.Instance.rp_pay_payment_method == false)
    //            frm.cmbMethod.Enabled = false;
    //        if (Main.Instance.rp_pay_gift_certificate == false)
    //            frm.btnGC.Enabled = false;

    //        if (Main.Instance.rp_pay_payment_method == true)
    //            frm.cmbMethod.Enabled = true;
    //        if (Main.Instance.rp_pay_gift_certificate == true)
    //            frm.btnGC.Enabled = true;
    //    }
    //}

    //public void More(More frm)
    //{
    //    if (Main.Instance.by_pass_user)
    //    {
    //        if (Main.Instance.bp_more_ejournal == false)
    //            frm.btnEJournal.Enabled = false;
    //        if (Main.Instance.bp_more_customer_membership == false)
    //            frm.btnCustomers.Enabled = false;
    //        if (Main.Instance.bp_more_logs == false)
    //            frm.btnLogs.Enabled = false;
    //        if (Main.Instance.bp_more_redeem_settings == false)
    //            frm.btnRedeemSettings.Enabled = false;
    //        if (Main.Instance.bp_more_manage_discounts == false)
    //            frm.btnManageDiscounts.Enabled = false;
    //        if (Main.Instance.bp_more_manage_products == false)
    //            frm.btnManageProducts.Enabled = false;
    //        if (Main.Instance.bp_more_inventory == false)
    //            frm.btnInventory.Enabled = false;
    //        if (Main.Instance.bp_more_close_store == false)
    //            frm.btnEnd.Enabled = false;
    //        if (Main.Instance.bp_more_database == false)
    //            frm.btnDatabase.Enabled = false;
    //        if (Main.Instance.bp_more_settings == false)
    //            frm.btnSettings.Enabled = false;

    //        if (Main.Instance.bp_more_ejournal == true)
    //            frm.btnEJournal.Enabled = true;
    //        if (Main.Instance.bp_more_customer_membership == true)
    //            frm.btnCustomers.Enabled = true;
    //        if (Main.Instance.bp_more_logs == true)
    //            frm.btnLogs.Enabled = true;
    //        if (Main.Instance.bp_more_redeem_settings == true)
    //            frm.btnRedeemSettings.Enabled = true;
    //        if (Main.Instance.bp_more_manage_discounts == true)
    //            frm.btnManageDiscounts.Enabled = true;
    //        if (Main.Instance.bp_more_manage_products == true)
    //            frm.btnManageProducts.Enabled = true;
    //        if (Main.Instance.bp_more_inventory == true)
    //            frm.btnInventory.Enabled = true;
    //        if (Main.Instance.bp_more_close_store == true)
    //            frm.btnEnd.Enabled = true;
    //        if (Main.Instance.bp_more_database == true)
    //            frm.btnDatabase.Enabled = true;
    //        if (Main.Instance.bp_more_settings == true)
    //            frm.btnSettings.Enabled = true;
    //    }
    //    else
    //    {
    //        if (Main.Instance.rp_more_ejournal == false)
    //            frm.btnEJournal.Enabled = false;
    //        if (Main.Instance.rp_more_customer_membership == false)
    //            frm.btnCustomers.Enabled = false;
    //        if (Main.Instance.rp_more_logs == false)
    //            frm.btnLogs.Enabled = false;
    //        if (Main.Instance.rp_more_redeem_settings == false)
    //            frm.btnRedeemSettings.Enabled = false;
    //        if (Main.Instance.rp_more_manage_discounts == false)
    //            frm.btnManageDiscounts.Enabled = false;
    //        if (Main.Instance.rp_more_manage_products == false)
    //            frm.btnManageProducts.Enabled = false;
    //        if (Main.Instance.rp_more_inventory == false)
    //            frm.btnInventory.Enabled = false;
    //        if (Main.Instance.rp_more_close_store == false)
    //            frm.btnEnd.Enabled = false;
    //        if (Main.Instance.rp_more_database == false)
    //            frm.btnDatabase.Enabled = false;
    //        if (Main.Instance.rp_more_settings == false)
    //            frm.btnSettings.Enabled = false;

    //        if (Main.Instance.rp_more_ejournal == true)
    //            frm.btnEJournal.Enabled = true;
    //        if (Main.Instance.rp_more_customer_membership == true)
    //            frm.btnCustomers.Enabled = true;
    //        if (Main.Instance.rp_more_logs == true)
    //            frm.btnLogs.Enabled = true;
    //        if (Main.Instance.rp_more_redeem_settings == true)
    //            frm.btnRedeemSettings.Enabled = true;
    //        if (Main.Instance.rp_more_manage_discounts == true)
    //            frm.btnManageDiscounts.Enabled = true;
    //        if (Main.Instance.rp_more_manage_products == true)
    //            frm.btnManageProducts.Enabled = true;
    //        if (Main.Instance.rp_more_inventory == true)
    //            frm.btnInventory.Enabled = true;
    //        if (Main.Instance.rp_more_close_store == true)
    //            frm.btnEnd.Enabled = true;
    //        if (Main.Instance.rp_more_database == true)
    //            frm.btnDatabase.Enabled = true;
    //        if (Main.Instance.rp_more_settings == true)
    //            frm.btnSettings.Enabled = true;
    //    }
    //}
}
