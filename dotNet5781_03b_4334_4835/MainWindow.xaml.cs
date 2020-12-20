﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

using System.Threading;

namespace dotNet5781_03b_4334_4835
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Bus bus { get; set; }
        ObservableCollection<Bus> busses = new ObservableCollection<Bus>();
        private static BackgroundWorker backgroundWorker = new BackgroundWorker();

    
        
        public MainWindow()
        {
            InitializeComponent();
            Busses(busses);
            
            busDataGrid.DataContext = busses;
            busDataGrid.IsReadOnly = true;
            backgroundWorker.DoWork += Backroundworker_DoWork;
            backgroundWorker.RunWorkerCompleted += Backroundworker_WorkerCompleted;
            backgroundWorker.WorkerReportsProgress = true;
        }
        /*adding busses*/
         private void Busses(ObservableCollection<Bus> busses)
        {
            busses.Add(new Bus(busses, "12345078", new DateTime(2019, 05, 25), 1200, 19800));//Needs checkup for date and sum km
            busses.Add(new Bus(busses, "12005678", new DateTime(2019, 12, 25), 200, 800));//almost needs checkup for date
            busses.Add(new Bus(busses, "22345678", new DateTime(2020, 05, 30), 1200, 19000));//good to go for another 1000 km
            busses.Add(new Bus(busses, "12945678", new DateTime(2020, 10, 12), 1000, 0));//good to go
            busses.Add(new Bus(busses, "12365678", new DateTime(2020, 07, 05), 10, 500));//low gas
            busses.Add(new Bus(busses, "18345678", new DateTime(2018, 08, 01), 1100, 600));//needs checkup
            busses.Add(new Bus(busses, "15345678", new DateTime(2020, 10, 02), 1150, 70));//ggod to go
            busses.Add(new Bus(busses, "12340678", new DateTime(2020, 05, 15), 300, 100));//ggod to go
            busses.Add(new Bus(busses, "12347878", new DateTime(2020, 09, 20), 250, 10000));//good to go
            busses.Add(new Bus(busses, "1234566", new DateTime(2017, 06, 30), 15, 4000));//needs checkup and low on gas*/


        }


        /*addbus*/
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            AddBus window = new AddBus();
            window.ShowDialog();
            Bus b = window.NewBUS;
            try
            {
                foreach (Bus bus in busses)
                {
                    if (bus.License_Plate == b.License_Plate)
                    {
                        throw new ArgumentException("License plate already exists");
                    }
                }

                busses.Add(b);
                b.checkupDate = b.Start_Date;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }




        }
        /*double cliking to show bus detailes*/
        public void ContentControl_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            Bus b = (busDataGrid.SelectedItem as Bus);

            BusStatus window1 = new BusStatus(b);
            window1.Show();

        }
        private void TravelButton_Click(object sender, RoutedEventArgs e)
        { 
            Travel win = new Travel(busDataGrid.SelectedItem as Bus);
            win.Show();
        }

        private void RefuelButton_Click(object sender, RoutedEventArgs e)
        {
           
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();//calling Backroundworker_DoWork
            }
 
        }
        private void Backroundworker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                bus = (busDataGrid.SelectedItem as Bus);
            });
            
            for (int i = 0; i <= 12; i++)//2 hours
            {
                System.Threading.Thread.Sleep(1000);
                

            }
            bus.Refuel();
            bus.Status = "Ready";
            
        }
        private void Backroundworker_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Bus has been refuled");//will show when bakroundworker ends



        }

    }






        
 }

