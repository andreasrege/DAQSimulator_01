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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DAQSimulator_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Sensor tSensor;
        public MainWindow()
        {
            InitializeComponent();
            tSensor = new Sensor("TestSens01", "AI", "Temp", "Room1");
            //tSensor.GetValue();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtNextReadTime.Text = tSensor.GetValue().ToString();
        }
    }
}
