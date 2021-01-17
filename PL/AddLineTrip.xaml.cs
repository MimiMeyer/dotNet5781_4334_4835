using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddLineTrip.xaml
    /// </summary>
    public partial class AddLineTrip : Window
    {
        private BO.LineTrip lineTrip = new BO.LineTrip();
        public AddLineTrip()
        {
            InitializeComponent();
            LineTripGrid.DataContext = lineTrip;
            
        }

        public BO.LineTrip NewLineTrip { get { return lineTrip; } }//returns user input 

      
    }
}
