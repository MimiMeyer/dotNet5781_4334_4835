using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

using System.Threading;

namespace dotNet5781_03b_4334_4835
{
    /// <summary>
    /// Interaction logic for BusStatus.xaml
    /// </summary>
    public partial class BusStatus : Window
    {
        public static Bus bus { get; set; }
      
        private static BackgroundWorker backgroundWorker1 = new BackgroundWorker();

        private static BackgroundWorker backgroundWorker2 = new BackgroundWorker();
        public BusStatus(Bus b)
        {
            InitializeComponent();
            busStatusDataGrid.DataContext = b;
            bus = b;
            backgroundWorker1.DoWork += Background_DoWorkGas;
            backgroundWorker2.DoWork += Background_DoWorkCheck;
            backgroundWorker1.RunWorkerCompleted += Backroundworker_WorkerCompletedGas;
            backgroundWorker2.RunWorkerCompleted += Backroundworker_WorkerCompletedCheck;
            
        }
        private void Button_Refuel(object sender, System.EventArgs e )
        {
            
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();//calls backroundworker1 dowork
            }


        }
        private void Background_DoWorkGas(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 12; i++)//12 seconds is 2 hours
            {
                System.Threading.Thread.Sleep(1000);
                
            }
            bus.Refuel();
            bus.Status = "Ready";
        }
     
        private void Backroundworker_WorkerCompletedGas(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Bus has been refuled"); //will show when backgroundWorker1 is finshed(end of refuel)
        }


        private void Button_CHECK(object sender, System.EventArgs e )
        {
            
            if (!backgroundWorker2.IsBusy)
            {
                backgroundWorker2.RunWorkerAsync();//calls backroundworker2 dowork
            }

        }
        private void Background_DoWorkCheck(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 144; i++)// 144 seconds is 24 hours
            {
                System.Threading.Thread.Sleep(1000);
                
            }
            bus.Checkup();
            bus.Status = "Ready";
        }
       

        private void Backroundworker_WorkerCompletedCheck(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Bus has been Checked");//will show when  backgroundWorker2 is finshed(checkup is done)
        }
    }


}
