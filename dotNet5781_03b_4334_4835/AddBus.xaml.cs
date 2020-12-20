using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace dotNet5781_03b_4334_4835
{
    /// <summary>
    /// Interaction logic for AddBus.xaml
    /// </summary>
    /// allows user to add bus 
    public partial class AddBus : Window
    {
        private Bus Bus1 = new Bus();
        public AddBus()
        {
            InitializeComponent();
           
                this.DataContext = Bus1;//gets user input
            
            
        }
        public Bus NewBUS { get { return Bus1; } }//returns user input (main window uses this function)


        
    }
}
