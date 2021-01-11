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
    /// Interaction logic for AddLine.xaml
    /// </summary>
    public partial class AddLine : Window
    {private BO.Line line=new BO.Line();
        public AddLine()
        {
            InitializeComponent();
            LineGrid.DataContext = line;//new line
            areaComboBox.ItemsSource = Enum.GetValues(typeof (BO.Areas));//combo box for areas

        }
        public BO.Line NewLine { get { return line; } }//returns user input 



    }
}
