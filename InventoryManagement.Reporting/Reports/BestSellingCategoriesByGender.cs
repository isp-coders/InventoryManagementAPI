using System;
using DevExpress.XtraReports.UI;

namespace InventoryManagement.Reporting.Reports
{
    public partial class BestSellingCategoriesByGender
    {
        public BestSellingCategoriesByGender()
        {
            InitializeComponent();
        }

        private void Gender_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            int Gender = int.Parse(GetCurrentColumnValue("Gender").ToString());
            if (Gender == 0)
                GenderCell.Text = "Erkek";
            else
                GenderCell.Text = "Kadýn";
        }

        private void tableCell4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
