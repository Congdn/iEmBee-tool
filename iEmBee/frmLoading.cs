using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iEmBee
{
    public partial class frmLoading : Form
    {
        private readonly MethodInvoker method;
        public frmLoading(MethodInvoker action)
        {
            InitializeComponent();
            tmrLoad.Start();
            method = action;
        }
        private void tmrLoad_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformLayout();
        }

        public static void InvokeAction(Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(action);
            }
            else
            {
                action();
            }
        }

        private void frmLoading_Load(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                method.Invoke();
                InvokeAction(this, Dispose);
                MessageBox.Show("Hoàn thành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }).Start();
        }
    }
}
