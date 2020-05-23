using CosmaticShop.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmaticShop.SourceCode
{
    public class ComboHelper
    {
        public static void FillUserTypes(ComboBox cmb)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserTypeID");
            dt.Columns.Add("UserType");
            dt.Rows.Add("0", "----Select Type----");
            var dbdt = DatabaseAccess.Retrive("Select UserTypeID,UserType from UserTypeTable");
            if(dbdt != null)
            {
                if(dbdt.Rows.Count > 0)
                {
                    foreach(DataRow types in dbdt.Rows)
                    {
                        dt.Rows.Add(types["UserTypeID"], types["UserType"]);
                    }
                }
            }
            cmb.DataSource = dt;
            cmb.DisplayMember = "UserType";
            cmb.ValueMember = "UserTypeID";
        }

        public static void Categories(ComboBox cmb)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CategoryID");
            dt.Columns.Add("Name");
            dt.Rows.Add("0", "----Select Type----");
            var dbdt = DatabaseAccess.Retrive("Select CategoryID,Name from CategeryTable");
            if (dbdt != null)
            {
                if (dbdt.Rows.Count > 0)
                {
                    foreach (DataRow types in dbdt.Rows)
                    {
                        dt.Rows.Add(types["CategoryID"], types["Name"]);
                    }
                }
            }
            cmb.DataSource = dt;
            cmb.DisplayMember = "Name";
            cmb.ValueMember = "CategoryID";
        }

        public static void Products(ComboBox cmb, string categoryid)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ItemID");
            dt.Columns.Add("Name");
            dt.Rows.Add("0", "----Select Type----");
            var dbdt = DatabaseAccess.Retrive("Select ItemID,Name from StockTable where CategoryID = '"+categoryid+"'");
            if (dbdt != null)
            {
                if (dbdt.Rows.Count > 0)
                {
                    foreach (DataRow types in dbdt.Rows)
                    {
                        dt.Rows.Add(types["ItemID"], types["Name"]);
                    }
                }
            }
            cmb.DataSource = dt;
            cmb.DisplayMember = "Name";
            cmb.ValueMember = "ItemID";
        }

        public static void ExpensesCategories(ComboBox cmb)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ExpCategoryID");
            dt.Columns.Add("Name");
            dt.Rows.Add("0", "----Select Type----");
            var dbdt = DatabaseAccess.Retrive("Select ExpCategoryID,Name from ExpensesCategoryTable");
            if (dbdt != null)
            {
                if (dbdt.Rows.Count > 0)
                {
                    foreach (DataRow types in dbdt.Rows)
                    {
                        dt.Rows.Add(types["ExpCategoryID"], types["Name"]);
                    }
                }
            }
            cmb.DataSource = dt;
            cmb.DisplayMember = "Name";
            cmb.ValueMember = "ExpCategoryID";
        }


    }
}
