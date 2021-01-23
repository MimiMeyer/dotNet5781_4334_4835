using BLAPI;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PL
{
    /// <summary>
    /// Interaction logic for Simulation.xaml
    /// </summary>
    public partial class Simulation : Window
    {

        BackgroundWorker timeWorker = new BackgroundWorker();//will use for threads
        BackgroundWorker TimeBoard = new BackgroundWorker();//will use for threads
        TimeSpan updateTime;//the time 
        int rate = new int();//the rate
        TimeSpan Day = new TimeSpan(1, 0, 0, 0);//a day
        int station;
        IBL bl = BLFactory.GetBL("1");

        public Simulation(int Code)
        {
            InitializeComponent();
            header.Text = " עבור מספר תחנה" + " " + Code;

            Rate.Text = rate.ToString();//puts 0 in the rate text box
            startTime.Text = updateTime.ToString();//will show timespan in start time textbox
            timeWorker.DoWork += timeWorker_DoWork;
            timeWorker.WorkerSupportsCancellation = true;//allows to cancle thread
            timeWorker.ProgressChanged += TimeWorker_ProgressChanged;
            timeWorker.WorkerReportsProgress = true;//allows to report progress
            timeWorker.RunWorkerCompleted += timeWorker_RunWorkerCompleted;//will do when Timework is finished

            TimeBoard.DoWork += TimeBoard_DoWork;
            TimeBoard.WorkerSupportsCancellation = true;//allows to cancle thread
            TimeBoard.ProgressChanged += TimeBoard_ProgressChanged;
            TimeBoard.WorkerReportsProgress = true;//allows to cancle thread

            station = Code;

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!timeWorker.IsBusy && !TimeBoard.IsBusy)//if not busy
            {


                timeWorker.RunWorkerAsync();//start timework and calls dowork
                TimeBoard.RunWorkerAsync();//start timeboard
                Button.Content = "Stop";//new content
                Button.Background = Brushes.Red;//new backround
                Rate.IsReadOnly = true;//can't change while the program is running
                startTime.IsReadOnly = true;//can't change while the program is running
            }
            else
            {
                timeWorker.CancelAsync();//stops the dowork for Timeworker
                TimeBoard.CancelAsync();//stops the do wrok for timeboard

            }
        }

        public void timeWorker_DoWork(Object sender, DoWorkEventArgs e)
        {

            this.Dispatcher.Invoke(() =>//lets us use  rate and upatetime even though they are owned  by diffrent thred
            {
                try
                {
                    rate = int.Parse(Rate.Text);//getting users input and converting from string to int
                
                updateTime = TimeSpan.Parse(startTime.Text);////getting users input and converting from string to TimeSpan
                }
                catch (OverflowException ex)//makes sure its timespan
                {
                    MessageBox.Show(ex.Message);//makes sure its int
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                }




            });

            if (rate > 0)//we don't want 0 because you cant devide a number by 0 and it cant be minus
            {
                for (int i = 1; ; i++)//will go on forever untill user presses bus
                {
                    System.Threading.Thread.Sleep(1000 / rate);//will go by rate lets say my rate is 50 so for every second, 50 seconds will pass
                    timeWorker.ReportProgress(i);
                    if (timeWorker.CancellationPending)//if timewworker was cancled leave loop
                    {
                        break;
                    }
                }
            }
        }
        private void TimeWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            if (startTime.Text == "23:59:59")
            {
                updateTime = updateTime.Add(TimeSpan.FromSeconds(e.ProgressPercentage).Subtract(Day));
                startTime.Text = (updateTime).ToString();//will show 00:00:00

            }
            else
                startTime.Text = (updateTime.Add(TimeSpan.FromSeconds(e.ProgressPercentage))).ToString();//will raise the text by one second

        }
        private void timeWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Button.Content = "Start Again";//function will never end but this will show when cancled
            Button.Background = Brushes.LightGreen;
            Rate.IsReadOnly = false;//can change once the program stopped
            startTime.IsReadOnly = false; //can change once the program stopped
        }
        private void TimeBoard_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Dispatcher.Invoke(() =>//lets us use  rate and upatetime even though they are owned  by diffrent thred
            {
                try
                {
                    rate = int.Parse(Rate.Text);//getting users input and converting from string to int
                
                    updateTime = TimeSpan.Parse(startTime.Text);////getting users input and converting from string to TimeSpan
                }
                catch (OverflowException ex)//makes sure its timespan
                {
                    MessageBox.Show(ex.Message);//makes sure its int
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            });
            if (updateTime.Days == 0)
            {
                if (rate > 0)//we don't want 0 because you cant devide a number by 0 and it cant be minus
                {
                    for (int j = 1; ; j++)//will go on forever untill user presses bus
                    {
                        System.Threading.Thread.Sleep(1000 / rate);//will go by rate lets say my rate is 50 so for every second, 50 seconds will pass
                        TimeBoard.ReportProgress(j);
                        if (timeWorker.CancellationPending)//if timewworker was cancled leave loop
                        {
                            break;
                        }
                    }
                }
                else
                {
                    this.Dispatcher.Invoke(() =>//lets us use  rate and upatetime even though they are owned  by diffrent thred
                    {
                        try
                        {
                            LastBusTextBox.Text = bl.LastBusInStation(TimeSpan.Parse(startTime.Text), station).ToString();//gets the last bus
                        }
                        catch (BO.StationCodeException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        catch (OverflowException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    });
                }
            }
            else
                MessageBox.Show("Time has to be in format of hours:minutes:seconds");



        }
        private void TimeBoard_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                lineTimingDataGrid.DataContext = bl.GetLineTimingForSimulator(TimeSpan.Parse(startTime.Text), station);//gets the info from the bl with the function GetLineTimingForSimulator

                LastBusTextBox.Text = bl.LastBusInStation(TimeSpan.Parse(startTime.Text), station).ToString();//gets the last bus
            }
            catch (BO.StationCodeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


    }

}



