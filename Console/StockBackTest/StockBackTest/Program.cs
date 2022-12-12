using IronXL;
using StockBackTest.Models;

class Program
{
    #region Constants
    private const string FILE_PATH = @"C:\Users\Siva Ranjani\Desktop\Mani\Console\StockBackTest\StockBackTest\Files\TempData.xlsx";
    private const int DATE_COLUMN_INDEX = 0;
    private const int OPEN_PRICE_COLUMN_INDEX = 1;
    private const int CLOSE_PRICE_COLUMN_INDEX = 2;
    private const int SIGNAL_COLUMN_INDEX = 8;
    #endregion

    #region Publics
    public static void Main(string[] args)
    {
        if (args is null) throw new ArgumentNullException(nameof(args));

        WorkBook excel = WorkBook.Load(FILE_PATH);

        List<BackTestResult> lstResult = GetBackTestResult(excel);
        ConvertResultToExcel(lstResult);
    }
    #endregion

    #region Privates
    private static List<BackTestResult> GetBackTestResult(WorkBook excel)
    {
        float fEntryPrice = 0;
        float fExitPrice;
        bool bStartMonitor = false, bStartTrailingSL = false;
        string strEntryDate = string.Empty, strExitDate;
        List<BackTestResult> lstResult = new();

        RangeRow[] signalColumnRows = excel.WorkSheets[0].Columns[SIGNAL_COLUMN_INDEX].Rows;

        for (int i = 21; i < signalColumnRows.Length; i++)
        {
            float fPreviousSignalRowValue = GetRowValue(signalColumnRows[i - 1]);
            float fCurrentSignalRowValue = GetRowValue(signalColumnRows[i]);

            if(bStartMonitor && (fCurrentSignalRowValue >= 100 || fCurrentSignalRowValue < -100))
            {
                fExitPrice = GetRowValue(excel.WorkSheets[0].Columns[OPEN_PRICE_COLUMN_INDEX].Rows[i + 1]);

                if (fCurrentSignalRowValue >= 100) bStartTrailingSL = true;

                if(bStartTrailingSL)
                {
                    if (fCurrentSignalRowValue > fPreviousSignalRowValue) continue;
                    else
                    {
                        fExitPrice = GetRowValue(excel.WorkSheets[0].Columns[OPEN_PRICE_COLUMN_INDEX].Rows[i]);
                        bStartTrailingSL = false;
                    }
                }
                
                strExitDate = excel.WorkSheets[0].Columns[DATE_COLUMN_INDEX].Rows[i + 1].ToString();

                float fPorLAmount = fExitPrice - fEntryPrice;
                float fPorLPercentage = (fPorLAmount * 100) / fEntryPrice;

                lstResult.Add(new BackTestResult() { 
                                                        EntryPrice = fEntryPrice,
                                                        ExitPrice = fExitPrice,
                                                        ProfitOrLossAmount = fPorLAmount,
                                                        ProfitOrLossPercentage = fPorLPercentage,
                                                        EntryDate = strEntryDate,
                                                        ExitDate = strExitDate
                                                   });

                bStartMonitor = false;
                continue;
            }

            if (fCurrentSignalRowValue >= -100 && fPreviousSignalRowValue < -100)
            {
                fEntryPrice = GetRowValue(excel.WorkSheets[0].Columns[CLOSE_PRICE_COLUMN_INDEX].Rows[i]);
                strEntryDate = excel.WorkSheets[0].Columns[DATE_COLUMN_INDEX].Rows[i].ToString();
                bStartMonitor = true;
            }
        }

        return lstResult;
    }

    private static float GetRowValue(RangeRow row)
    {
        return float.Parse(row.ToString());
    }

    private static void ConvertResultToExcel(List<BackTestResult> lstResult)
    {
        WorkBook wbBackTest = WorkBook.Create(ExcelFileFormat.XLSX);
        WorkSheet wsBackTestResult = wbBackTest.CreateWorkSheet("BackTestResult");

        wsBackTestResult["A1"].Value = "S.No";
        wsBackTestResult["B1"].Value = "Entry Date";
        wsBackTestResult["C1"].Value = "Entry Price";
        wsBackTestResult["D1"].Value = "Exit Date";
        wsBackTestResult["E1"].Value = "Exit Price";
        wsBackTestResult["F1"].Value = "Profit Or Loss";
        wsBackTestResult["G1"].Value = "Profit Or Loss Percentage";

        for(int i = 1; i <= lstResult.Count; i++)
        {
            int j = i + 1;
            int k = i - 1;

            wsBackTestResult[$"A{j}"].Value = i;
            wsBackTestResult[$"B{j}"].Value = lstResult[k].EntryDate;
            wsBackTestResult[$"C{j}"].Value = lstResult[k].EntryPrice;
            wsBackTestResult[$"D{j}"].Value = lstResult[k].ExitDate;
            wsBackTestResult[$"E{j}"].Value = lstResult[k].ExitPrice;
            wsBackTestResult[$"F{j}"].Value = lstResult[k].ProfitOrLossAmount;
            wsBackTestResult[$"G{j}"].Value = lstResult[k].ProfitOrLossPercentage;

            if (lstResult[k].ProfitOrLossAmount > 0)
            {
                wsBackTestResult[$"F{j}"].Style.BackgroundColor = "#B2F9B3";
                wsBackTestResult[$"G{j}"].Style.BackgroundColor = "#B2F9B3";
            }
            else
            {
                wsBackTestResult[$"F{j}"].Style.BackgroundColor = "#FD866E";
                wsBackTestResult[$"G{j}"].Style.BackgroundColor = "#FD866E";
            }
        }

        wbBackTest.SaveAs(@"C:\Users\Siva Ranjani\Desktop\Mani\Console\StockBackTest\StockBackTest\BackTestResults\Test.xlsx");
    }
    #endregion
}