using DevExpress.XtraReports.UI;
using InventoryManagement.Reporting.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Reporting.ReportCreators
{
    public class ProductLabelReportCreator
    {
        public XtraReport CreateReport(XtraReport report, string url)
        {
            //?ReportName = ProductLabel % 3FProductBarcode % 3D120380100001
            string paramName = url.Substring(url.IndexOf("?") + 1, url.IndexOf("=") - (url.IndexOf("?") + 1));
            string[] paramValue = url.Substring(url.IndexOf("=") + 1).Split(",");
            report.Parameters[paramName].Value = paramValue;
            report.Parameters[paramName].Visible = true;
            report.RequestParameters = false;
            return report;
        }
    }
}
