using DevExpress.XtraReports.UI;

namespace InventoryManagement.Reporting.ReportCreators
{
    public class EodReportCreator
    {
        public XtraReport CreateReport(XtraReport report, string url)
        {
            int indexOfQuestion = url.IndexOf("?");
            int indexOfEquals = url.IndexOf("=");
            if (indexOfQuestion != -1 && indexOfEquals != -1)
            {
                string paramName = url.Substring(url.IndexOf("?") + 1, url.IndexOf("=") - (url.IndexOf("?") + 1));
                string paramValue = url.Substring(url.IndexOf("=") + 1).Split(",")[0];
                report.Parameters[paramName].Value = paramValue;
                report.Parameters[paramName].Visible = true;
                report.RequestParameters = false;
            }

            return report;
        }


        public byte[] ExportToPdf(XtraReport report, string url)
        {
            report = CreateReport(report, url);
            System.IO.MemoryStream pdfStream = new System.IO.MemoryStream();
            report.ExportToPdf(pdfStream);
            return pdfStream.ToArray();
        }
    }
}
