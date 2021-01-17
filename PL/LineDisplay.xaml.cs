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
    /// Interaction logic for LineDisplay.xaml
    /// </summary>
    public partial class LineDisplay : Window
    {
        IBL bl = BLFactory.GetBL("1");
        public LineDisplay()
        {
            InitializeComponent();
            lineDataGrid.DataContext = bl.GetAlllines();//all lines 
            lineDataGrid.IsReadOnly = true;//cant change
            

        }
        private void Details_Click(object sender, RoutedEventArgs e)//will open LineDetails window pratim
        {
            LineDetails window = new LineDetails(lineDataGrid.SelectedItem as BO.Line);//sending line that was chosen to LineDetails
            window.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//will  open LineCrud window peulut nosfot
        {
            LineCrud window = new LineCrud();
            window.Show();
        }
        private void LineTrip_Click(object sender, RoutedEventArgs e)//will  open LineCrud window peulut nosfot
        {
            LineTrip window = new LineTrip(lineDataGrid.SelectedItem as BO.Line);
            window.Show();
        }
        private void ADDLineTrip_Click(object sender, RoutedEventArgs e)//add start at
        {
            AddLineTrip window = new AddLineTrip();
            window.ShowDialog();
            try
            {
                BO.LineTrip lineTrip = window.NewLineTrip;
                bl.AddLineTrip(lineTrip);
            }
            catch(BO.LineIdException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
