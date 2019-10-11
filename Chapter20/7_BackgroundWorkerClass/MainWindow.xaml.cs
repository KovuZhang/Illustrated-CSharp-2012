using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _7_BackgroundWorkerClass
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker bgWorker = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();

            // 设置 BackgroundWorker 属性
            bgWorker.WorkerReportsProgress = true;  // 允许工作线程为主线程回报进度
            bgWorker.WorkerSupportsCancellation = true;     // 允许从主线程取消工作线程

            // 连接 BackgroundWorker 对象的处理程序
            bgWorker.DoWork += BgWorker_DoWork; // 包含后台线程事件执行程序
            bgWorker.ProgressChanged += BgWorker_ProgressChanged;   // 后台线程向主线程回报时触发事件
            bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;     // 后台线程完成 DoWork 中包含的事件后触发的事件
        }

        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            processBar.Value = 100;

            if (e.Cancelled)
            {
                MessageBox.Show("Process was cancelled", "Progress Cancelled");
            }
            else
            {
                MessageBox.Show("Process completed normally", "Progress Completed");
            }
        }

        private void BgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            processBar.Value = e.ProgressPercentage;
        }

        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;   // as 运算符 用于强制类型转换

            for (int i = 0; i < 10; i++)
            {
                // 调用 CancelAsync 方法会让 CancellationPending 属性设置为 true
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    worker.ReportProgress(i * 10);
                    Thread.Sleep(500);
                }
            }
        }

        private void BtnProgress_Click(object sender, RoutedEventArgs e)
        {
            if (!bgWorker.IsBusy)
            {
                bgWorker.RunWorkerAsync();  // 调用当前方法会获取后台线程并执行 DoWork 中的事件
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            bgWorker.CancelAsync();
        }
    }
}
