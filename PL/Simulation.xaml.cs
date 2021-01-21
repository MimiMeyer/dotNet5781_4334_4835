using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for Simulation.xaml
    /// </summary>
    public partial class Simulation : Window
    {
        
        BackgroundWorker timeWorker=new BackgroundWorker();
        TimeSpan updateTime;
        int rate = new int();
        int r = new int();
       
        
        public Simulation()
        {
            InitializeComponent();
            Rate.Text = rate.ToString();
          
            startTime.Text = updateTime.ToString();
            timeWorker.DoWork += timeWorker_DoWork;
            timeWorker.WorkerSupportsCancellation = true;//allows to cancle
            timeWorker.ProgressChanged += timeWorker_ProgressChanged;
            timeWorker.WorkerReportsProgress = true;
            timeWorker.RunWorkerCompleted += timeWorker_RunWorkerCompleted;


        }

        private void timeWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Button.Content = "Start Again";
        }

        private void timeWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            startTime.Text = (updateTime.Add(TimeSpan.FromSeconds(e.ProgressPercentage)).ToString());
        }

        public void timeWorker_DoWork(Object sender,DoWorkEventArgs e) 
        {
            
            this.Dispatcher.Invoke(() =>
            {
                r = int.Parse(Rate.Text);
                updateTime = TimeSpan.Parse(startTime.Text);
               
                
            });

            if (r >0)
            {
                for (int i = 0; ; i++)
                {
                    System.Threading.Thread.Sleep(1000/r);//will go by rate lets say my rate is 50 so for every second, 50 seconds will pass
                    timeWorker.ReportProgress(i);
                    if (timeWorker.CancellationPending)
                    {
                        break;
                    }
                } 
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!timeWorker.IsBusy)
            {
               
              
                timeWorker.RunWorkerAsync();
                Button.Content = "Stop";
            }
            else
            {
                timeWorker.CancelAsync();
                Button.Content = "Start";

            }
        }
    }
}
