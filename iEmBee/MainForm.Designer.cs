namespace iEmBee
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnInput = new System.Windows.Forms.Button();
            this.btnOuput = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxInput12 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxInput2 = new System.Windows.Forms.TextBox();
            this.lswRes = new System.Windows.Forms.ListView();
            this.cbxPhanTramOrder = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCountRecord = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxInput1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxOutput1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxOutput2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxOutput12 = new System.Windows.Forms.TextBox();
            this.lblPatch = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxCompanyName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxCompanyAddress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxPhone = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cbxHangToiThieu = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnInput
            // 
            this.btnInput.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInput.Location = new System.Drawing.Point(29, 20);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(129, 39);
            this.btnInput.TabIndex = 0;
            this.btnInput.Text = "Chọn file...";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // btnOuput
            // 
            this.btnOuput.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOuput.Location = new System.Drawing.Point(683, 356);
            this.btnOuput.Name = "btnOuput";
            this.btnOuput.Size = new System.Drawing.Size(129, 39);
            this.btnOuput.TabIndex = 11;
            this.btnOuput.Text = "Xuất file...";
            this.btnOuput.UseVisualStyleBackColor = true;
            this.btnOuput.Click += new System.EventHandler(this.btnExportInput_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tổng nhập n-3:";
            // 
            // tbxInput12
            // 
            this.tbxInput12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxInput12.Location = new System.Drawing.Point(221, 213);
            this.tbxInput12.Name = "tbxInput12";
            this.tbxInput12.Size = new System.Drawing.Size(174, 30);
            this.tbxInput12.TabIndex = 5;
            this.tbxInput12.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxInput12_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tổng nhập n-1:";
            // 
            // tbxInput2
            // 
            this.tbxInput2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxInput2.Location = new System.Drawing.Point(222, 307);
            this.tbxInput2.Name = "tbxInput2";
            this.tbxInput2.Size = new System.Drawing.Size(174, 30);
            this.tbxInput2.TabIndex = 9;
            this.tbxInput2.TextChanged += new System.EventHandler(this.tbxInput2_TextChanged);
            // 
            // lswRes
            // 
            this.lswRes.FullRowSelect = true;
            this.lswRes.GridLines = true;
            this.lswRes.Location = new System.Drawing.Point(12, 405);
            this.lswRes.Name = "lswRes";
            this.lswRes.Size = new System.Drawing.Size(813, 323);
            this.lswRes.TabIndex = 12;
            this.lswRes.UseCompatibleStateImageBehavior = false;
            this.lswRes.View = System.Windows.Forms.View.Details;
            // 
            // cbxPhanTramOrder
            // 
            this.cbxPhanTramOrder.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPhanTramOrder.FormattingEnabled = true;
            this.cbxPhanTramOrder.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20"});
            this.cbxPhanTramOrder.Location = new System.Drawing.Point(651, 47);
            this.cbxPhanTramOrder.Name = "cbxPhanTramOrder";
            this.cbxPhanTramOrder.Size = new System.Drawing.Size(161, 30);
            this.cbxPhanTramOrder.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(647, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 22);
            this.label4.TabIndex = 12;
            this.label4.Text = "Hàng tối đa/ngày:";
            // 
            // lblCountRecord
            // 
            this.lblCountRecord.AutoSize = true;
            this.lblCountRecord.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountRecord.Location = new System.Drawing.Point(206, 31);
            this.lblCountRecord.Name = "lblCountRecord";
            this.lblCountRecord.Size = new System.Drawing.Size(0, 22);
            this.lblCountRecord.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tổng nhập n-2:";
            // 
            // tbxInput1
            // 
            this.tbxInput1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxInput1.Location = new System.Drawing.Point(221, 261);
            this.tbxInput1.Name = "tbxInput1";
            this.tbxInput1.Size = new System.Drawing.Size(174, 30);
            this.tbxInput1.TabIndex = 7;
            this.tbxInput1.TextChanged += new System.EventHandler(this.tbxInput1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(433, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 22);
            this.label5.TabIndex = 7;
            this.label5.Text = "Tổng xuất n-2:";
            // 
            // tbxOutput1
            // 
            this.tbxOutput1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxOutput1.Location = new System.Drawing.Point(637, 263);
            this.tbxOutput1.Name = "tbxOutput1";
            this.tbxOutput1.Size = new System.Drawing.Size(179, 30);
            this.tbxOutput1.TabIndex = 8;
            this.tbxOutput1.TextChanged += new System.EventHandler(this.tbxOutput1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(433, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 22);
            this.label6.TabIndex = 9;
            this.label6.Text = "Tổng xuất n-1:";
            // 
            // tbxOutput2
            // 
            this.tbxOutput2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxOutput2.Location = new System.Drawing.Point(637, 309);
            this.tbxOutput2.Name = "tbxOutput2";
            this.tbxOutput2.Size = new System.Drawing.Size(179, 30);
            this.tbxOutput2.TabIndex = 10;
            this.tbxOutput2.TextChanged += new System.EventHandler(this.tbxOutput2_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(433, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 22);
            this.label7.TabIndex = 5;
            this.label7.Text = "Tổng xuất n-3:";
            // 
            // tbxOutput12
            // 
            this.tbxOutput12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxOutput12.Location = new System.Drawing.Point(637, 215);
            this.tbxOutput12.Name = "tbxOutput12";
            this.tbxOutput12.Size = new System.Drawing.Size(179, 30);
            this.tbxOutput12.TabIndex = 6;
            this.tbxOutput12.TextChanged += new System.EventHandler(this.tbxOutput12_TextChanged);
            // 
            // lblPatch
            // 
            this.lblPatch.AutoSize = true;
            this.lblPatch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatch.Location = new System.Drawing.Point(26, 365);
            this.lblPatch.Name = "lblPatch";
            this.lblPatch.Size = new System.Drawing.Size(0, 22);
            this.lblPatch.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(25, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 22);
            this.label8.TabIndex = 24;
            this.label8.Text = "Tên khách hàng:";
            // 
            // tbxCompanyName
            // 
            this.tbxCompanyName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCompanyName.Location = new System.Drawing.Point(221, 88);
            this.tbxCompanyName.Name = "tbxCompanyName";
            this.tbxCompanyName.Size = new System.Drawing.Size(591, 30);
            this.tbxCompanyName.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(25, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 22);
            this.label9.TabIndex = 26;
            this.label9.Text = "Địa chỉ:";
            // 
            // tbxCompanyAddress
            // 
            this.tbxCompanyAddress.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCompanyAddress.Location = new System.Drawing.Point(222, 124);
            this.tbxCompanyAddress.Name = "tbxCompanyAddress";
            this.tbxCompanyAddress.Size = new System.Drawing.Size(590, 30);
            this.tbxCompanyAddress.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(25, 163);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 22);
            this.label10.TabIndex = 28;
            this.label10.Text = "Điện thoại:";
            // 
            // tbxPhone
            // 
            this.tbxPhone.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPhone.Location = new System.Drawing.Point(222, 160);
            this.tbxPhone.Name = "tbxPhone";
            this.tbxPhone.Size = new System.Drawing.Size(590, 30);
            this.tbxPhone.TabIndex = 4;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(548, 356);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(129, 39);
            this.btnClear.TabIndex = 29;
            this.btnClear.Text = "Xóa dữ liệu";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(455, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(173, 22);
            this.label11.TabIndex = 31;
            this.label11.Text = "Hàng tối thiểu/Ngày:";
            // 
            // cbxHangToiThieu
            // 
            this.cbxHangToiThieu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxHangToiThieu.FormattingEnabled = true;
            this.cbxHangToiThieu.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20"});
            this.cbxHangToiThieu.Location = new System.Drawing.Point(470, 46);
            this.cbxHangToiThieu.Name = "cbxHangToiThieu";
            this.cbxHangToiThieu.Size = new System.Drawing.Size(152, 30);
            this.cbxHangToiThieu.TabIndex = 1;
            this.cbxHangToiThieu.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(839, 740);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbxHangToiThieu);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbxPhone);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbxCompanyAddress);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbxCompanyName);
            this.Controls.Add(this.lblPatch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxOutput1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbxOutput2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbxOutput12);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxInput1);
            this.Controls.Add(this.lblCountRecord);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxPhanTramOrder);
            this.Controls.Add(this.lswRes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxInput2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxInput12);
            this.Controls.Add(this.btnOuput);
            this.Controls.Add(this.btnInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iEmBee";
            this.Load += new System.EventHandler(this.IEmBee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Button btnOuput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxInput12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxInput2;
        private System.Windows.Forms.ListView lswRes;
        private System.Windows.Forms.ComboBox cbxPhanTramOrder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCountRecord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxInput1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxOutput1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxOutput2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxOutput12;
        private System.Windows.Forms.Label lblPatch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxCompanyName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxCompanyAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxPhone;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbxHangToiThieu;
    }
}

