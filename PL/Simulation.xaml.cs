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
        int rate;
        public Simulation()
        {
            InitializeComponent();
            Rate.DataContext = rate;
            timeWorker.DoWork += timeWorker_DoWork;



        }
        public void timeWorker_DoWork(Object sender,DoWorkEventArgs e) 
        { 

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
