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
        double[] arrListValues;
        int aSensorCount = 10;
        double sampleTime = 5500; //milliseconds
        double logTime = 58; //seconds
        DateTime dtSampStart;
        DateTime dtLogStart;
        double elapsedTimeSampling;
        double elapsedTimeLog;
        public MainWindow()
        {
            InitializeComponent();

            
            /*if (elapsedTimeSampling >= sampleTime)
            {
                btnReadSensVal
            }
            else
            { btnReadSensVal.IsEnabled = false; }
            */
            int aSensorCount = 10;
            arrListValues = new double[aSensorCount];
            arrSensor = new AnalogSensor[aSensorCount];
            
            for (int i=0; i< aSensorCount; i++)
            {
                arrSensor[i] = new AnalogSensor(i, "","","","",-1,1);
               //arrListValues[i] = arrSensor[i].GetValue();
               //lstView1.Items.Add(arrListValues[i].ToString());
               

            }
           // txtList.Text = arrListValues[2].ToString();
            //tSensor.GetValue();
        }



        private void btnLogToFile_Click(object sender, RoutedEventArgs e)
        {
            lstViewLogVals.Items.Clear();
            elapsedTimeLog = Convert.ToDouble(Math.Truncate(DateTime.Now.Subtract(dtLogStart).TotalSeconds));
            if (elapsedTimeLog >= logTime)
            {
                txtNextLogTime.Clear();
                dtLogStart = DateTime.Now;
                for (int j = 0; j < aSensorCount; j++)
                {
                    arrListValues[j] = arrSensor[j].GetValue();
                    lstViewLogVals.Items.Add("Sensor " + (1 + j) + " value: " + arrListValues[j].ToString());
                }
            }
            else
            {
                txtNextLogTime.Text = "Required elapsed time between logging not acheived!";
                txtNextLogTime.Text = (logTime - elapsedTimeLog).ToString();
            }
        }

        

        private void btnReadSensVal_Click(object sender, RoutedEventArgs e)
        {
            lstView1.Items.Clear();
            elapsedTimeSampling = Convert.ToDouble(Math.Truncate(DateTime.Now.Subtract(dtSampStart).TotalMilliseconds));
            if (elapsedTimeSampling >= sampleTime)
            {
                txtNextLogTime.Clear();
                txtNextReadTime.Clear();
                // last = now;
                dtSampStart = DateTime.Now;
                for (int j = 0; j < aSensorCount; j++)
                {
                    arrListValues[j] = arrSensor[j].GetValue();
                    lstView1.Items.Add("Sensor " + (1 + j) + " value: " + arrListValues[j].ToString());
                }
            }
            else
            {
                txtNextLogTime.Text = "Requireds sampling time not acheived!";
                txtNextReadTime.Text = ((sampleTime - elapsedTimeSampling) / 1000.0).ToString();
            }
        }
    }
}
