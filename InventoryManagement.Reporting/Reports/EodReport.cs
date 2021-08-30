using System;
using System.Data;
using DevExpress.XtraReports.UI;

namespace InventoryManagement.Reporting.Reports
{
    public partial class EodReport
    {
        public EodReport()
        {
            InitializeComponent();
        }

        private void ProductTypeBeforePrint(object sender, DevExpress.XtraReports.UI.CrossTab.CrossTabCellPrintEventArgs e)
        {

        }
    }
}
