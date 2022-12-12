namespace StockBackTest.Models
{
    public class BackTestResult
    {
        public float EntryPrice { get; set; }
        public float ExitPrice { get; set; }
        public float ProfitOrLossAmount { get; set; }
        public float ProfitOrLossPercentage { get; set; }
        public string? EntryDate { get; set; }
        public string? ExitDate { get; set; }
    }
}
