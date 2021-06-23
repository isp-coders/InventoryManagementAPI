using DevExpress.XtraReports.UI;
using InventoryManagement.Reporting.PredefinedReports;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InventoryManagement.Reporting.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportPdfController : Controller
    {

        [HttpGet("GetReportPdf")]
        public ActionResult GetReportPdf(string url)
        {
            try
            {
                int IndexOfQustionMark = url.IndexOf("?");
                string reportName = "";
                if (IndexOfQustionMark > 0)
                    reportName = url.Substring(0, IndexOfQustionMark);
                else
                {
                    reportName = url;
                }
                if (ReportsFactory.Reports.ContainsKey(reportName))
                {

                    XtraReport report = ReportsFactory.Reports[reportName]();
                    Type type = Type.GetType($"InventoryManagement.Reporting.ReportCreators.{reportName}ReportCreator", true);
                    object instance = Activator.CreateInstance(type);
                    byte[] memoryStream = instance.GetType().GetMethod("ExportToPdf").Invoke(instance, new object[] { report, url }) as byte[];
                    return File(memoryStream, "application/pdf");

                }
                else
                {
                    return BadRequest("Not Found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Could not get report data.");
            }
        }
    }
}
