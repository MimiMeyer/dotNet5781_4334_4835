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
    /// Interaction logic for LineCrud.xaml
    /// </summary>
    public partial class LineCrud : Window
    {
        IBL bl = BLFactory.GetBL("1");
        public LineCrud()
        {
            
            InitializeComponent();
            lineDataGrid.DataContext = bl.GetAlllines();//gets lines
            lineDataGrid.IsReadOnly = true;
        }
        private void Update_Click(object sender, RoutedEventArgs e)//shows LineStation where we can delete and update linestations 
        {
            BO.Line line = lineDataGrid.SelectedItem as BO.Line;
            LineStation window = new LineStation(line);
            window.ShowDialog();

        }
        private void Delete_Click(object sender, RoutedEventArgs e)//deletes line
        {
            BO.Line line = lineDataGrid.SelectedItem as BO.Line;//the wanted line
            try
            {
                bl.DeleteLine(line.Id);//deletes line
            }
            
            catch (BO.LineIdException ex)
            {
                MessageBox.Show(ex.Message);//if line doesnt exist
            }

        }
        
        private void AddStation_Click(object sender, RoutedEventArgs e)//add line station to line and opens AddLineStation
        {
            BO.Line line = lineDataGrid.SelectedItem as BO.Line;//wanted line
            AddLineStation window = new AddLineStation();
            window.ShowDialog();
           BO.LineStation station= window.NewStation;//get user input line station
            station.LineId = line.Id;//gets the line id
            try 
            {
                bl.AddStationToLine(station);//add station to line
            }
            catch (BO.LineStationIndexException ex)
            {
                MessageBox.Show(ex.Message);//if index isnt correct
            }
            catch (BO.StationCodeException ex)
            {
                MessageBox.Show(ex.Message);//if station already exists in line or if station doesnt exist
            }
            catch (BO.LineIdException ex)
            {
                MessageBox.Show(ex.Message);//if line doesnt exist
            }
            catch (BO.CantBeMinusException ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)//add bus and opens AddLine window 
        {
            
            AddLine window = new AddLine();
            window.ShowDialog();
           BO.Line line= window.NewLine;//gets users line
            try
            {
                bl.AddLine(line);//add bus
            }
            catch (BO.LineIdException ex) 
            {
                MessageBox.Show(ex.Message);//if line has back and forth buses or isnt the back and forth will send exception
            }
            catch (BO.StationCodeException ex)
            {
                MessageBox.Show(ex.Message);// if first and last station dont exist
            }
   
    }
        

    }
}
