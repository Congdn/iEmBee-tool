using System;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace iEmBee
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        private void IEmBee_Load(object sender, EventArgs e)
        {
            cbxPhanTramOrder.Text = "10";
            cbxHangToiThieu.Text = "1";
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpen = new OpenFileDialog();
            fileOpen.Filter = "(Tệp Excel)|*.xlsx|(Tất cả tệp)|*.*";
            fileOpen.ShowDialog();
            if (fileOpen.FileName != "") lblPatch.Text = fileOpen.FileName;
            ImportData(fileOpen, lblCountRecord);
        }
        void ImportData(OpenFileDialog fileOpen, Label lblCountRecord)
        {
            if (fileOpen.FileName != "")
            {
                Excel.Application excel = new Excel.Application();
                Excel.Workbook wb = excel.Workbooks.Open(fileOpen.FileName);
                decimal BuyTotal = 0, SaleTotal = 0;
                try
                {
                    Excel._Worksheet sheet = wb.Sheets[1];
                    Excel.Range range = sheet.UsedRange;
                    int rows = range.Rows.Count;
                    lblCountRecord.Text = (rows - 1).ToString() + " bản ghi";
                    int cols = range.Columns.Count;
                    //title
                    for (int i = 1; i <= cols; i++)
                    {
                        string columnName = range.Cells[1, i].Value.ToString();
                        ColumnHeader col = new ColumnHeader();
                        col.Text = columnName;
                        if (i == 2) col.Width = 285;
                        else
                        {
                            col.TextAlign = HorizontalAlignment.Center;
                            col.Width = 75;
                        }
                        lswRes.Columns.Add(col);
                    }
                    //item
                    for (int i = 2; i <= rows; i++)
                    {
                        ListViewItem item = new ListViewItem();
                        for (int j = 1; j <= cols; j++)
                        {
                            if (j == 1) item.Text = range.Cells[i, j].Value.ToString();
                            else item.SubItems.Add(range.Cells[i, j].Value.ToString());
                            if (j == 4) BuyTotal += Convert.ToDecimal(range.Cells[i, j].Value.ToString());
                            if (j == 5) SaleTotal += Convert.ToDecimal(range.Cells[i, j].Value.ToString());
                        }
                        lswRes.Items.Add(item);
                    }
                    MessageBox.Show("Hoàn thành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    //Tổng
                    ListViewItem total = new ListViewItem();
                    total.Text = "";
                    total.SubItems.Add("Tổng");
                    total.SubItems.Add("");
                    total.SubItems.Add(BuyTotal.ToString());
                    total.SubItems.Add(SaleTotal.ToString());
                    lswRes.Items.Add(total);

                    wb.Close();
                    excel.Quit();
                }
            }
            else
            {
                MessageBox.Show("Bạn không chọn tệp nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExportInput_Click(object sender, EventArgs e)
        {
            if (lswRes.Items.Count == 0) MessageBox.Show("Chưa có dữ liệu");
            else
            {
                decimal buyTotal12 = 0,
                    buyTotal1 = 0,
                    buyTotal2 = 0,
                    saleTotal12 = 0,
                    saleTotal1 = 0,
                    saleTotal2 = 0;
                if (tbxOutput12.Text != "") saleTotal12 = Convert.ToDecimal(tbxOutput12.Text);
                if (tbxOutput1.Text != "") saleTotal1 = Convert.ToDecimal(tbxOutput1.Text);
                if (tbxOutput2.Text != "") saleTotal2 = Convert.ToDecimal(tbxOutput2.Text);
                if (tbxInput12.Text != "") buyTotal12 = Convert.ToDecimal(tbxInput12.Text);
                if (tbxInput1.Text != "") buyTotal1 = Convert.ToDecimal(tbxInput1.Text);
                if (tbxInput2.Text != "") buyTotal2 = Convert.ToDecimal(tbxInput2.Text);
                var items = (double)lswRes.Items.Count;
                var SoLuongToiDa = Convert.ToDouble(cbxPhanTramOrder.Text);
                var SoLuongToiThieu = Convert.ToDouble(cbxHangToiThieu.Text);
                //var OrderCount = Math.Round((items / 100) * PercentOrder);
                if (SoLuongToiDa <= 0) SoLuongToiDa = 1;
                if (SoLuongToiThieu <= 0) SoLuongToiThieu = 1;
                if (SoLuongToiThieu > SoLuongToiDa) MessageBox.Show("Số lượng tối thiểu phải nhỏ hơn số lượng tối đa");
                else { 
                    //Path lưu file
                    var index = lblPatch.Text.LastIndexOf(@"\");
                    var Path = lblPatch.Text.Remove(index, lblPatch.Text.Length - index);
                    string name = "Tên khách hàng", address = "Địa chỉ", phone = "Số điện thoại";
                    if (tbxCompanyName.Text != "") name = tbxCompanyName.Text;
                    if (tbxCompanyAddress.Text != "") address = tbxCompanyAddress.Text;
                    if (tbxPhone.Text != "") phone = tbxPhone.Text;
                    ExportExcel export = new ExportExcel();
                    //Tạo thư mục
                    Path = Path + @"\" + DateTime.Now.ToString("dd-MM-yy");
                    Directory.CreateDirectory(Path);
                    
                    new frmLoading(()=>
                    export.Export(SoLuongToiDa, SoLuongToiThieu, 12, buyTotal12, saleTotal12, lswRes, Path, name, address, phone)).ShowDialog();
                    new frmLoading(()=>
                    export.Export(SoLuongToiDa, SoLuongToiThieu, 1, buyTotal1, saleTotal1, lswRes, Path, name, address, phone)).ShowDialog();
                    new frmLoading(()=>
                    export.Export(SoLuongToiDa, SoLuongToiThieu, 2, buyTotal2, saleTotal2, lswRes, Path, name, address, phone)).ShowDialog();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var test = lblPatch.Text.LastIndexOf(@"\");
            var test2 = lblPatch.Text.Remove(test, lblPatch.Text.Length - test);
            MessageBox.Show(test2.ToString());
        }

        private void tbxInput12_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbxInput12.Text))
                {
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                    double valueBefore = Int64.Parse(tbxInput12.Text, System.Globalization.NumberStyles.AllowThousands);
                    tbxInput12.Text = String.Format(culture, "{0:N0}", valueBefore);
                    tbxInput12.Select(tbxInput12.Text.Length, 0);
                }
            }
            catch
            {
                tbxInput12.Text = "";
                MessageBox.Show("Chỉ nhập số 0 - 9", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxOutput12_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbxOutput12.Text))
                {
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                    double valueBefore = Int64.Parse(tbxOutput12.Text, System.Globalization.NumberStyles.AllowThousands);
                    tbxOutput12.Text = String.Format(culture, "{0:N0}", valueBefore);
                    tbxOutput12.Select(tbxOutput12.Text.Length, 0);
                }

            }
            catch
            {
                tbxOutput12.Text = "";
                MessageBox.Show("Chỉ nhập số 0 - 9", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxInput1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbxInput1.Text))
                {
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                    double valueBefore = Int64.Parse(tbxInput1.Text, System.Globalization.NumberStyles.AllowThousands);
                    tbxInput1.Text = String.Format(culture, "{0:N0}", valueBefore);
                    tbxInput1.Select(tbxInput1.Text.Length, 0);
                }
            }
            catch
            {
                tbxInput1.Text = "";
                MessageBox.Show("Chỉ nhập số 0 - 9", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxInput2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbxInput2.Text))
                {
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                    double valueBefore = Int64.Parse(tbxInput2.Text, System.Globalization.NumberStyles.AllowThousands);
                    tbxInput2.Text = String.Format(culture, "{0:N0}", valueBefore);
                    tbxInput2.Select(tbxInput2.Text.Length, 0);
                }
            }
            catch
            {
                tbxInput2.Text = "";
                MessageBox.Show("Chỉ nhập số 0 - 9", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxOutput1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbxOutput1.Text))
                {
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                    double valueBefore = Int64.Parse(tbxOutput1.Text, System.Globalization.NumberStyles.AllowThousands);
                    tbxOutput1.Text = String.Format(culture, "{0:N0}", valueBefore);
                    tbxOutput1.Select(tbxOutput1.Text.Length, 0);
                }
            }
            catch
            {
                tbxOutput1.Text = "";
                MessageBox.Show("Chỉ nhập số 0 - 9", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxOutput2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbxOutput2.Text))
                {
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                    double valueBefore = Int64.Parse(tbxOutput2.Text, System.Globalization.NumberStyles.AllowThousands);
                    tbxOutput2.Text = String.Format(culture, "{0:N0}", valueBefore);
                    tbxOutput2.Select(tbxOutput2.Text.Length, 0);
                }
            }
            catch
            {
                tbxOutput2.Text = "";
                MessageBox.Show("Chỉ nhập số 0 - 9", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblPatch.Text = "";
            lblCountRecord.Text = "";
            lswRes.Columns.Clear();
            lswRes.Items.Clear();
            tbxInput12.Text = "";
            tbxInput1.Text = "";
            tbxInput2.Text = "";
            tbxOutput12.Text = "";
            tbxOutput1.Text = "";
            tbxOutput2.Text = "";
            cbxPhanTramOrder.Text = "10";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
