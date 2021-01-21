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
using BLAPI;

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
        TimeSpan Twelve = new TimeSpan(1,0, 0, 0);

        IBL bl = BLFactory.GetBL("1");
             
        public Simulation()
        {
            InitializeComponent();
            Rate.Text = rate.ToString();
          
            startTime.Text = updateTime.ToString();
            timeWorker.DoWork += timeWorker_DoWork;
            timeWorker.WorkerSupportsCancellation = true;//allows to cancle thread
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

           if (startTime.Text == "23:59:59") 
            {
                updateTime=updateTime.Add(TimeSpan.FromSeconds(e.ProgressPercentage).Subtract(Twelve));
                startTime.Text = (updateTime).ToString();

            }
            startTime.Text = (updateTime.Add(TimeSpan.FromSeconds(e.ProgressPercentage))).ToString();
        }

        public void timeWorker_DoWork(Object sender,DoWorkEventArgs e) 
        {
            
            this.Dispatcher.Invoke(() =>
            {
                rate = int.Parse(Rate.Text);
                updateTime = TimeSpan.Parse(startTime.Text);


            });

            if (rate >0)
            {
                for (int i = 1; ; i++)
                {
                    System.Threading.Thread.Sleep(1000/rate);//will go by rate lets say my rate is 50 so for every second, 50 seconds will pass
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
