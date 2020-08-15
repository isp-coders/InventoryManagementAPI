using DevExpress.XtraReports.UI;
using InventoryManagement.Reporting.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Reporting.PredefinedReports
{
    public static class ReportsFactory
    {
        public static Dictionary<string, Func<XtraReport>> Reports = new Dictionary<string, Func<XtraReport>>()
        {
            ["ProductTicket"] = () => new ProductLabel()
        };
    }
}