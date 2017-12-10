using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example9._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = true;
            button2.Enabled = false;
        }
        System.Threading.CancellationTokenSource cts;
        private async void button1_Click(object sender, EventArgs e)
        {
            //await StartTask();

            var task = StartTask();
            var cts = new System.Threading.CancellationTokenSource(TimeSpan.FromSeconds(1));
            var token = cts.Token;
            try
            {
                //这里的取消操作会抛出OperationCanceledException异常，但是task仍然会正常执行完成
                task.Wait(token);
            }
            catch (OperationCanceledException)
            {

                MessageBox.Show("外部取消");
            }

        }

        private async Task StartTask()
        {
            button1.Enabled = false;
            button2.Enabled = true;
            var cancellTime = TimeSpan.FromSeconds(5);
            try
            {
                cts = new System.Threading.CancellationTokenSource(cancellTime);
                var token = cts.Token;
                var taskTime = TimeSpan.FromSeconds(3);
                await Task.Delay(taskTime, token);
                MessageBox.Show($"经过{taskTime}s,操作完成");
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show($"超过{cancellTime}s,操作已经取消");
            }
            finally
            {
                button1.Enabled = true;
                button2.Enabled = false;
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }
    }
}
