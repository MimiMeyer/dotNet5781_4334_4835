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
       /*shows details of requested bus and gives option to refuel or checkup*/
        public BusStatus(Bus b)
        {
            InitializeComponent();
            busStatusDataGrid.DataContext = b;////copying the bus to the data grid
            bus = b;
            backgroundWorker1.DoWork += Background_DoWorkGas;//calling on new thread for refueling
            backgroundWorker2.DoWork += Background_DoWorkCheck;//calling on new thread for checkup
            backgroundWorker1.RunWorkerCompleted += Backroundworker_WorkerCompletedGas;//once thread is complete for refuelling
            backgroundWorker2.RunWorkerCompleted += Backroundworker_WorkerCompletedCheck;//once thread is complete for chekup

        }
        private void Button_Refuel(object sender, System.EventArgs e )
        {
            
            if (!backgroundWorker1.IsBusy)//makes sure backround workeris not busy
            {
                backgroundWorker1.RunWorkerAsync();//calls Background_DoWorkGas
            }


        }
        /*when thread is called*/
        private void Background_DoWorkGas(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 12; i++)//12 seconds is 2 hours
            {
                System.Threading.Thread.Sleep(1000);//sleeps for 1 second
                
            }
            bus.Refuel();//refuel bus
            bus.Status = "Ready";//updating status
        }
        /*when thread ends*/
        private void Backroundworker_WorkerCompletedGas(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Bus has been refuled"); //will show when backgroundWorker1 is finshed(end of refuel)
        }


        private void Button_CHECK(object sender, System.EventArgs e )
        {
            
            if (!backgroundWorker2.IsBusy)//makes sure backround workeris not busy
            {
                backgroundWorker2.RunWorkerAsync();//calls Background_DoWorkCheck
            }

        }
        /*when thread is called*/
        private void Background_DoWorkCheck(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 144; i++)// 144 seconds is 24 hours
            {
                System.Threading.Thread.Sleep(1000);//sleeps for 1 second
                
            }
            bus.Checkup();//bus checkup and if gas is low also refuels
            bus.Status = "Ready";//updating status
        }

        /*when thread ends*/
        private void Backroundworker_WorkerCompletedCheck(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Bus has been Checked");//will show when  backgroundWorker2 is finshed(checkup is done)
        }
    }


}
