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

namespace Example9._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private CancellationTokenSource cts;
        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            try
            {
                cts = new CancellationTokenSource();
                var token = cts.Token;
                await Task.Delay(TimeSpan.FromSeconds(5), token);
                MessageBox.Show("执行成功");
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("操作已经取消");
            }
            catch (Exception ex)
            {
                MessageBox.Show("任务出错" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cts.Cancel();
            button1.Enabled = true;
            button2.Enabled = false;
        }
    }
}
