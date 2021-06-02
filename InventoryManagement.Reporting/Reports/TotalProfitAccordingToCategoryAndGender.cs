namespace InventoryManagement.Reporting.Reports
{
    public partial class TotalProfitAccordingToCategoryAndGender
    {
        public TotalProfitAccordingToCategoryAndGender()
        {
            InitializeComponent();
        }

        private void Gender_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            int Gender = int.Parse(GetCurrentColumnValue("Gender").ToString());
            if (Gender == 0)
                GenderText.Text = "Erkek";
            else
                GenderText.Text = "Kadýn";
        }
    }
}
