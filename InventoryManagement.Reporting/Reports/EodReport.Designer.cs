//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventoryManagement.Reporting.Reports {
    
    public partial class EodReport : DevExpress.XtraReports.UI.XtraReport {
        private void InitializeComponent() {
            DevExpress.XtraReports.ReportInitializer reportInitializer = new DevExpress.XtraReports.ReportInitializer(this, "InventoryManagement.Reporting.Reports.EodReport.repx");

            // Controls
            this.ReportHeader = reportInitializer.GetControl<DevExpress.XtraReports.UI.ReportHeaderBand>("ReportHeader");
            this.Detail = reportInitializer.GetControl<DevExpress.XtraReports.UI.DetailBand>("Detail");
            this.TopMargin = reportInitializer.GetControl<DevExpress.XtraReports.UI.TopMarginBand>("TopMargin");
            this.BottomMargin = reportInitializer.GetControl<DevExpress.XtraReports.UI.BottomMarginBand>("BottomMargin");
            this.label2 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("label2");
            this.label1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("label1");
            this.crossTab1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRCrossTab>("crossTab1");
            this.crossTabCell2 = reportInitializer.GetControl<DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell>("crossTabCell2");
            this.crossTabCell3 = reportInitializer.GetControl<DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell>("crossTabCell3");
            this.GenderCell = reportInitializer.GetControl<DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell>("GenderCell");
            this.crossTabCell5 = reportInitializer.GetControl<DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell>("crossTabCell5");
            this.crossTabCell6 = reportInitializer.GetControl<DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell>("crossTabCell6");
            this.ProductType = reportInitializer.GetControl<DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell>("ProductType");
            this.crossTabCell10 = reportInitializer.GetControl<DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell>("crossTabCell10");
            this.crossTabCell12 = reportInitializer.GetControl<DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell>("crossTabCell12");
            this.crossTabCell14 = reportInitializer.GetControl<DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell>("crossTabCell14");

            // Parameters
            this.ReportDate = reportInitializer.GetParameter("ReportDate");

            // Data Sources
            this.sqlDataSource1 = reportInitializer.GetDataSource<DevExpress.DataAccess.Sql.SqlDataSource>("sqlDataSource1");

            // Styles
            this.TitleStyle = reportInitializer.GetStyle("TitleStyle");
            this.crossTabGeneralStyle = reportInitializer.GetStyle("crossTabGeneralStyle");
            this.crossTabHeaderStyle = reportInitializer.GetStyle("crossTabHeaderStyle");
            this.crossTabDataStyle = reportInitializer.GetStyle("crossTabDataStyle");
            this.crossTabTotalStyle = reportInitializer.GetStyle("crossTabTotalStyle");
        }
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel label2;
        private DevExpress.XtraReports.UI.XRLabel label1;
        private DevExpress.XtraReports.UI.XRCrossTab crossTab1;
        private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabCell2;
        private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabCell3;
        private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell GenderCell;
        private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabCell5;
        private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabCell6;
        private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell ProductType;
        private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabCell10;
        private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabCell12;
        private DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell crossTabCell14;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.XRControlStyle TitleStyle;
        private DevExpress.XtraReports.UI.XRControlStyle crossTabGeneralStyle;
        private DevExpress.XtraReports.UI.XRControlStyle crossTabHeaderStyle;
        private DevExpress.XtraReports.UI.XRControlStyle crossTabDataStyle;
        private DevExpress.XtraReports.UI.XRControlStyle crossTabTotalStyle;
        private DevExpress.XtraReports.Parameters.Parameter ReportDate;
    }
}