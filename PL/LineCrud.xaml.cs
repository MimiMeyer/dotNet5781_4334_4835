﻿using System;
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
            lineDataGrid.DataContext = bl.GetAlllines();
            lineDataGrid.IsReadOnly = true;
        }
        private void Update_Click(object sender, RoutedEventArgs e)// delete or update linestation
        {
            BO.Line line = lineDataGrid.SelectedItem as BO.Line;
            LineStation window = new LineStation(line);
            window.ShowDialog();

        }
        private void Delete_Click(object sender, RoutedEventArgs e)//deletes line
        {
            BO.Line line = lineDataGrid.SelectedItem as BO.Line;
            try
            {
                bl.DeleteLine(line.Id);//deletes line
            }
            
            catch (BO.LineIdException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        private void AddStation_Click(object sender, RoutedEventArgs e)//add line station to line
        {
            BO.Line line = lineDataGrid.SelectedItem as BO.Line;
            AddLineStation window = new AddLineStation();
            window.ShowDialog();
           BO.LineStation station= window.NewStation;//get user input
            station.LineId = line.Id;
            try 
            {
                bl.AddStationToLine(station);
            }
            catch (BO.LineStationIndexException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (BO.StationCodeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (BO.LineIdException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)//add bus
        {
            
            AddLine window = new AddLine();
            window.ShowDialog();
           BO.Line line= window.NewLine;
            try
            {
                bl.AddLine(line);
            }
            catch (BO.LineIdException ex) 
            {
                MessageBox.Show(ex.Message);
            }
            catch (BO.StationCodeException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
