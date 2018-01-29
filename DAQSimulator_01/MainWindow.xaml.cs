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
        AnalogSensor[] arrSensor;
        int[] arrListValues;
        int aSensorCount = 10;
        //Sensor tSensor;
        public MainWindow()
        {
            InitializeComponent();

            testClass2 tC2 = new testClass2();
            tC2.name = "testClass2_Name";
            tC2.intClass2 = 2;

           // tSensor = new Sensor("TestSens01", "AI", "Temp", "Room1");
           // Console.WriteLine("Please specify number of analog sensors do create");
            int aSensorCount = 10;
            arrListValues = new int[aSensorCount];
            arrSensor = new AnalogSensor[aSensorCount];
            
            /*for (int i=0; i< aSensorCount-1; i++)
            {
               arrSensor[i] = new AnalogSensor();
               arrListValues[i] = arrSensor[i].GetValue();
               //lstView1.Items.Add(arrListValues[i].ToString());
               

            }*/
           // txtList.Text = arrListValues[2].ToString();
            //tSensor.GetValue();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtNextLogTime.Text = this.arrListValues[1].ToString();
            //lstView1.Items.Add(txtNextLogTime);
            //txtList.Text=//
            //txtNextReadTime.Text = tSensor.GetValue().ToString();
           // txtList.Text = arrListValues.ToString() ;
        }

        private void btnLogToFile_Click(object sender, RoutedEventArgs e)
        {
            //lstView1.Items.Add(txtNextLogTime.Text);
            //lstView1.Items.Add(arrListValues.GetValue().ToString());
            for (int i = 0; i < aSensorCount - 1; i++)
            {
                arrSensor[i] = new AnalogSensor();
               
                arrListValues[i] = arrSensor[i].GetValue();
                lstView1.Items.Add(arrListValues[i].ToString());
            }

        }
    }
}
