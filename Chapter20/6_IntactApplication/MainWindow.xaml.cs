using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _6_IntactApplication
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        CancellationTokenSource cts;
        CancellationToken ct;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BtnProcess_Click(object sender, RoutedEventArgs e)
        {
            btnProcess.IsEnabled = false;

            cts = new CancellationTokenSource();
            ct = cts.Token;

            int completedPercent = 0;
            for (int i = 0; i < 10; i++)
            {
                if (ct.IsCancellationRequested)
                {
                    break;
                }

                try
                {
                    await Task.Delay(500, ct);
                    completedPercent = (i + 1) * 10;
                }
                catch (TaskCanceledException ex)
                {
                    completedPercent = i * 10;
                }

                processBar.Value = completedPercent;
            }

            string message = ct.IsCancellationRequested
                    ? string.Format("Process was cancelled at {0}%.", completedPercent)
                    : "Process completed normally";
            MessageBox.Show(message, "Completion Status");

            processBar.Value = 0;
            btnProcess.IsEnabled = true;
            btnCancel.IsEnabled = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (!btnProcess.IsEnabled)
            {
                btnCancel.IsEnabled = false;
                cts.Cancel();
            }
        }
    }
}
