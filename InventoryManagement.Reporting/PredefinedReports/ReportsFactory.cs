using DevExpress.XtraReports.UI;
using InventoryManagement.Reporting.Reports;
using System;
using System.Collections.Generic;

namespace InventoryManagement.Reporting.PredefinedReports
{
    public static class ReportsFactory
    {
        public static Dictionary<string, Func<XtraReport>> Reports = new Dictionary<string, Func<XtraReport>>()
        {
            ["ProductLabel"] = () => new ProductLabel(),
            ["BestSellingProducts"] = () => new BestSellingProducts(),
            ["BestSellers"] = () => new BestSellers(),
            ["BestSellingCategories"] = () => new BestSellingCategories(),
            ["BestSellingColors"] = () => new BestSellingColors(),
            ["BestSellingSizes"] = () => new BestSellingSizes(),
            ["MostProfitableProducts"] = () => new MostProfitableProducts(),
            ["LeastProfitableProducts"] = () => new LeastProfitableProducts(),
            ["BestSellingCategoriesByGender"] = () => new BestSellingCategoriesByGender(),
            ["TotalProfitAccordingToCategoryAndGender"] = () => new TotalProfitAccordingToCategoryAndGender(),
            ["Eod"] = () => new EodReport()
        };
    }
}