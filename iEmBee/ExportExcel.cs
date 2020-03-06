using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace iEmBee
{
    public class ExportExcel
    {
        public void Export(double SoLuongToiDa, double SoLuongToiThieu, int Month, decimal BuyTotal, decimal SaleTotal, ListView lswRes, string Path, string companyName, string Address, string Phone)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook wb = excelApp.Workbooks.Add(Type.Missing);
            Excel._Worksheet ws = null,
                ws2 = null;
            excelApp.Windows.Application.ActiveWindow.DisplayGridlines = true;
            try
            {
                #region WorkSheet Bán hàng
                //header
                ws = wb.Worksheets[1];
                ws.Name = "Bán hàng";

                ws.Range[ws.Cells[1, 1], ws.Cells[1, lswRes.Columns.Count + 2]].Merge();
                ws.Range[ws.Cells[2, 1], ws.Cells[2, lswRes.Columns.Count + 2]].Merge();
                ws.Range[ws.Cells[3, 1], ws.Cells[3, lswRes.Columns.Count + 2]].Merge();
                ws.Range[ws.Cells[4, 1], ws.Cells[4, lswRes.Columns.Count + 2]].Merge();
                ws.Range[ws.Cells[5, 1], ws.Cells[5, lswRes.Columns.Count + 2]].Merge();
                //Tên công ty
                ws.Cells[1, 1].Value = companyName.ToUpper();
                ws.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                ws.Cells[1, 1].Font.Size = 20;
                //Địa chỉ
                ws.Cells[2, 1].Value = Address;
                ws.Cells[2, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                ws.Cells[2, 1].Font.Size = 14;
                //Điện thoại
                ws.Cells[3, 1].Value = "'" + Phone;
                ws.Cells[3, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                ws.Rows[3].Style.NumberFormat = "General";
                ws.Cells[3, 1].Font.Size = 12;
                //Tiêu đề
                if (Month == 12)
                    ws.Cells[4, 1].Value = "Bảng tổng hợp doanh số bán hàng tháng " + Month + "/2018";
                else
                    ws.Cells[4, 1].Value = "Bảng tổng hợp doanh số bán hàng tháng " + Month + "/2019";
                ws.Cells[4, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                ws.Cells[4, 1].Font.Size = 12;
                //Kẻ
                ws.Cells[6, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                //title
                for (int i = 1; i <= lswRes.Columns.Count; i++)
                {
                    if (i != 4) ws.Cells[6, i + 1] = lswRes.Columns[i - 1].Text;
                    if (i == 4) ws.Cells[6, i + 1] = "SL";
                    ws.Cells[6, i + 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    ws.Cells[6, i + 1].Font.Bold = true;
                    ws.Cells[6, i + 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                }
                ws.Cells[6, lswRes.Columns.Count + 2] = "Doanh thu";
                ws.Cells[6, lswRes.Columns.Count + 2].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                ws.Cells[6, lswRes.Columns.Count + 2].Font.Bold = true;
                ws.Cells[6, lswRes.Columns.Count + 2].Borders.Weight = Excel.XlBorderWeight.xlThin;
                //
                //Item
                Random random = new Random();
                Random OrderRandom = new Random();
                DateTime date;
                if (Month == 12) date = new DateTime(2018, Month, 1);
                else date = new DateTime(2019, Month, 1);
                decimal excelSaleTotal = 0;
                int autoNum = 1;
                //Vẽ bảng theo ngày
                while (date.Month == Month)
                {
                    Excel.Range rangeAdd = ws.UsedRange;
                    var rowsAdd = rangeAdd.Rows.Count;
                    //Thêm date
                    ws.Cells[rowsAdd + 1, 1] = "'" + date.ToString("dd/MM/yyyy");
                    ws.Cells[rowsAdd + 1, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    date = date.AddDays(1);
                    //
                    var orderQuatity = OrderRandom.Next(Convert.ToInt32(SoLuongToiThieu), Convert.ToInt32(SoLuongToiDa));
                    //Random số lượng hàng mỗi ngày
                    for (int i = 1; i <= orderQuatity; i++)
                    {
                        var rowRandom = random.Next(2, lswRes.Items.Count - 1);
                        ListViewItem item = lswRes.Items[rowRandom];
                        ws.Cells[rowsAdd + i, 2] = autoNum;
                        autoNum++;
                        ws.Cells[rowsAdd + i, 2].Borders.Weight = Excel.XlBorderWeight.xlThin;
                        //vẽ từng hàng
                        for (int j = 2; j <= lswRes.Columns.Count; j++)
                        {
                            ws.Cells[rowsAdd + i, j + 1] = item.SubItems[j - 1].Text;
                            ws.Cells[rowsAdd + i, j + 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                            if (j == 5)
                            {
                                excelSaleTotal += Convert.ToDecimal(item.SubItems[j - 1].Text);
                            }
                        }
                    }
                }
                //Số lượng trung bình từ tổng nhập và tổng giá bán
                double quantity = Math.Round(Convert.ToDouble(SaleTotal / excelSaleTotal));
                //clear excelSaleTotal
                excelSaleTotal = 0;
                Excel.Range range = ws.UsedRange;
                var rows = range.Rows.Count;
                //Add cột số lượng
                for (int i = 7; i <= rows; i++)
                {
                    double soLuong = quantity + random.Next(-2, 3);
                    if (soLuong <= 0)
                    {
                        ws.Cells[i, 5] = 1;
                        ws.Cells[i, 7] = Convert.ToDecimal(range.Cells[i, 6].Value.ToString());
                    }
                    else
                    {
                        ws.Cells[i, 5] = soLuong;
                        ws.Cells[i, 7] = (decimal)soLuong * Convert.ToDecimal(range.Cells[i, 6].Value.ToString());
                    }
                    excelSaleTotal += Convert.ToDecimal(range.Cells[i, 7].Value.ToString());

                    ws.Cells[i, 7].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    ws.Cells[i, 2].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    ws.Cells[i, 4].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    ws.Cells[i, 5].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }
                //
                ws.Cells[rows + 1, 3] = "Tổng";
                ws.Cells[rows + 1, 7] = excelSaleTotal.ToString();
                ws.Cells[rows + 1, 3].Borders.Weight = Excel.XlBorderWeight.xlThin;
                ws.Cells[rows + 1, 3].Font.Bold = true;
                ws.Cells[rows + 1, 7].Borders.Weight = Excel.XlBorderWeight.xlThin;
                ws.Cells[rows + 1, 7].Font.Bold = true;
                #endregion

                #region WorkSheet Nhập hàng
                //header
                ws2 = wb.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing)
                        as Excel.Worksheet;
                ws2.Name = "Nhập hàng";

                ws2.Range[ws2.Cells[1, 1], ws2.Cells[1, lswRes.Columns.Count + 2]].Merge();
                ws2.Range[ws2.Cells[2, 1], ws2.Cells[2, lswRes.Columns.Count + 2]].Merge();
                ws2.Range[ws2.Cells[3, 1], ws2.Cells[3, lswRes.Columns.Count + 2]].Merge();
                ws2.Range[ws2.Cells[4, 1], ws2.Cells[4, lswRes.Columns.Count + 2]].Merge();
                ws2.Range[ws2.Cells[5, 1], ws2.Cells[5, lswRes.Columns.Count + 2]].Merge();
                //Tên công ty
                ws2.Cells[1, 1].Value = companyName.ToUpper();
                ws2.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                ws2.Cells[1, 1].Font.Size = 20;
                //Địa chỉ
                ws2.Cells[2, 1].Value = Address;
                ws2.Cells[2, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                ws2.Cells[2, 1].Font.Size = 14;
                //Điện thoại
                ws2.Cells[3, 1].Value = "'" + Phone;
                ws2.Cells[3, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                ws2.Rows[3].Style.NumberFormat = "General";
                ws2.Cells[3, 1].Font.Size = 12;
                //Tiêu đề
                if (Month == 12)
                    ws2.Cells[4, 1].Value = "Bảng tổng hợp doanh số nhập hàng tháng " + Month + "/2018";
                else
                    ws2.Cells[4, 1].Value = "Bảng tổng hợp doanh số nhập hàng tháng " + Month + "/2019";
                ws2.Cells[4, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                ws2.Cells[4, 1].Font.Size = 12;
                //Kẻ
                ws2.Cells[6, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                //title
                for (int i = 1; i <= lswRes.Columns.Count; i++)
                {
                    if (i < 4) ws2.Cells[6, i + 1] = lswRes.Columns[i - 1].Text;
                    if (i == 4) ws2.Cells[6, i + 1] = "SL";
                    if (i == 5) ws2.Cells[6, i + 1] = lswRes.Columns[i - 2].Text;
                    ws2.Cells[6, i + 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    ws2.Cells[6, i + 1].Font.Bold = true;
                    ws2.Cells[6, i + 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                }
                ws2.Cells[6, lswRes.Columns.Count + 2] = "Giá vốn";
                ws2.Cells[6, lswRes.Columns.Count + 2].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                ws2.Cells[6, lswRes.Columns.Count + 2].Font.Bold = true;
                ws2.Cells[6, lswRes.Columns.Count + 2].Borders.Weight = Excel.XlBorderWeight.xlThin;
                //
                //Item
                DateTime date2;
                if (Month == 12) date2 = new DateTime(2018, Month, 1);
                else date2 = new DateTime(2019, Month, 1);
                decimal excelBuyTotal = 0;
                autoNum = 1;
                //Vẽ bảng theo ngày
                while (date2.Month == Month)
                {
                    Excel.Range rangeAdd = ws2.UsedRange;
                    var rowsAdd = rangeAdd.Rows.Count;
                    //Thêm date
                    ws2.Cells[rowsAdd + 1, 1] = "'" + date2.ToString("dd/MM/yyyy");
                    ws2.Cells[rowsAdd + 1, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    date2 = date2.AddDays(1);
                    //
                    var orderQuatity = OrderRandom.Next(Convert.ToInt32(SoLuongToiThieu), Convert.ToInt32(SoLuongToiDa));
                    //Random số lượng hàng mỗi ngày
                    for (int i = 1; i <= orderQuatity; i++)
                    {
                        var rowRandom = random.Next(2, lswRes.Items.Count - 1);
                        ListViewItem item = lswRes.Items[rowRandom];
                        ws2.Cells[rowsAdd + i, 2] = autoNum;
                        autoNum++;
                        ws2.Cells[rowsAdd + i, 2].Borders.Weight = Excel.XlBorderWeight.xlThin;
                        //vẽ từng hàng
                        for (int j = 2; j <= lswRes.Columns.Count; j++)
                        {
                            if (j < 4)
                            {
                                ws2.Cells[rowsAdd + i, j + 1] = item.SubItems[j - 1].Text;
                                ws2.Cells[rowsAdd + i, j + 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                            }
                            if (j == 5)
                            {
                                excelBuyTotal += Convert.ToDecimal(item.SubItems[j - 2].Text);
                                ws2.Cells[rowsAdd + i, j + 1] = item.SubItems[j - 2].Text;
                                ws2.Cells[rowsAdd + i, j + 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                            }
                        }
                    }
                }
                //Số lượng trung bình từ tổng nhập và tổng giá bán
                quantity = Math.Round(Convert.ToDouble(BuyTotal / excelBuyTotal));
                //clear excelBuyTotal
                excelBuyTotal = 0;
                Excel.Range range2 = ws2.UsedRange;
                rows = range2.Rows.Count;
                //Add cột số lượng
                for (int i = 7; i <= rows; i++)
                {
                    double soLuong = quantity + random.Next(-2, 3);
                    if (soLuong <= 0)
                    {
                        ws2.Cells[i, 5] = 1;
                        ws2.Cells[i, 7] = Convert.ToDecimal(range2.Cells[i, 6].Value.ToString());
                    }
                    else
                    {
                        ws2.Cells[i, 5] = soLuong;
                        ws2.Cells[i, 7] = (decimal)soLuong * Convert.ToDecimal(range2.Cells[i, 6].Value.ToString());
                    }
                    excelBuyTotal += Convert.ToDecimal(range2.Cells[i, 7].Value.ToString());

                    ws2.Cells[i, 7].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    ws2.Cells[i, 5].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    ws2.Cells[i, 2].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    ws2.Cells[i, 4].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    ws2.Cells[i, 5].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }
                //
                ws2.Cells[rows + 1, 3] = "Tổng";
                ws2.Cells[rows + 1, 7] = excelBuyTotal.ToString();
                ws2.Cells[rows + 1, 3].Borders.Weight = Excel.XlBorderWeight.xlThin;
                ws2.Cells[rows + 1, 3].Font.Bold = true;
                ws2.Cells[rows + 1, 7].Borders.Weight = Excel.XlBorderWeight.xlThin;
                ws2.Cells[rows + 1, 7].Font.Bold = true;
                #endregion

                //Một số thông số định dạng worksheet
                #region FormatStyle
                //
                ws.Columns[1].Style.Font.Size = 12;
                ws.Columns[1].ColumnWidth = 10;
                ws.Columns[1].Style.NumberFormat = "dd/mm/yyyy";

                ws2.Columns[1].Style.Font.Size = 12;
                ws2.Columns[1].ColumnWidth = 10;
                ws2.Columns[1].Style.NumberFormat = "dd/mm/yyyy";

                ws.Columns[2].Style.Font.Size = 12;
                ws.Columns[2].ColumnWidth = 6;
                ws.Columns[2].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                ws2.Columns[2].Style.Font.Size = 12;
                ws2.Columns[2].ColumnWidth = 6;
                ws2.Columns[2].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                ws.Columns[3].Style.Font.Size = 12;
                ws.Columns[3].ColumnWidth = 35;

                ws2.Columns[3].Style.Font.Size = 12;
                ws2.Columns[3].ColumnWidth = 35;

                ws.Columns[4].Style.Font.Size = 12;
                ws.Columns[4].ColumnWidth = 4;
                ws.Columns[4].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                ws2.Columns[4].Style.Font.Size = 12;
                ws2.Columns[4].ColumnWidth = 4;
                ws2.Columns[4].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                ws.Columns[5].Style.Font.Size = 12;
                ws.Columns[5].ColumnWidth = 4;
                ws.Columns[5].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                ws2.Columns[5].Style.Font.Size = 12;
                ws2.Columns[5].ColumnWidth = 4;
                ws2.Columns[5].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                ws.Columns[6].Style.Font.Size = 12;
                ws.Columns[6].ColumnWidth = 11;
                ws.Columns[6].Style.NumberFormat = "#,##0";

                ws2.Columns[6].Style.Font.Size = 12;
                ws2.Columns[6].ColumnWidth = 11;
                ws2.Columns[6].Style.NumberFormat = "#,##0";

                ws.Columns[7].Style.Font.Size = 12;
                ws.Columns[7].ColumnWidth = 13;
                ws.Columns[7].Style.NumberFormat = "#,##0";

                ws2.Columns[7].Style.Font.Size = 12;
                ws2.Columns[7].ColumnWidth = 13;
                ws2.Columns[7].Style.NumberFormat = "#,##0";

                ws.Rows.Font.Name = "Times New Roman";
                ws.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
                ws.PageSetup.TopMargin = 27;
                ws.PageSetup.RightMargin = 27;
                ws.PageSetup.BottomMargin = 27;
                ws.PageSetup.LeftMargin = 56;
                
                ws2.Rows.Font.Name = "Times New Roman";
                ws2.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4;
                ws2.PageSetup.TopMargin = 27;
                ws2.PageSetup.RightMargin = 27;
                ws2.PageSetup.BottomMargin = 27;
                ws2.PageSetup.LeftMargin = 56;
                #endregion
                wb.SaveAs(Path + @"\Output_" + Month + ".xlsx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.ReleaseComObject(ws);
                if (ws2 != null) Marshal.ReleaseComObject(ws2);
                wb.Close(false);
                Marshal.FinalReleaseComObject(wb);
                excelApp.Quit();
                Marshal.FinalReleaseComObject(excelApp);
            }
        }

    }
}
