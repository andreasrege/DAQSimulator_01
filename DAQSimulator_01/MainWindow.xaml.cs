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
using System.IO;

namespace DAQSimulator_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AnalogSensor[] arrAnalogSensor;
        DigitalSensor[] arrDigSensor;
        Log logFile;
        Scale scaleSensor2;
        Filter filter;
        double[] filteredVal = new double[7];
        double[] arrListValues;
        int[] arrListDigValues;
        int aSensorCount = 7;
        int dSensorCount = 3;
        double sampleTime = 550; //milliseconds
        double logTime = 5; //seconds
        DateTime dtSampStart;
        DateTime dtLogStart;
        double elapsedTimeSampling;
        double elapsedTimeLog;
        int aMinRange=-1;
        int aMaxRange=1;
        int aRes = Convert.ToInt32(Math.Pow(2,22));
        int dRes = Convert.ToInt32(Math.Pow(2,1));

        string path = @"C:\Users\andreas\Documents\_Skole\Visual Studio code\LogFiles\log333.csv";
        bool fileExist;
        public MainWindow()
        {


            InitializeComponent();

            logFile = new Log(path);
            fileExist = logFile.checkFileExist();

            scaleSensor2 = new Scale(aMinRange, aMaxRange,-100,+100);

            txtList.Text = fileExist.ToString();

            arrListValues = new double[aSensorCount];
            arrAnalogSensor = new AnalogSensor[aSensorCount];

            arrListDigValues = new int[dSensorCount];
            arrDigSensor = new DigitalSensor[dSensorCount];

            filter = new Filter();

            //Creating analog sensors
            for (int i=0; i< aSensorCount; i++)
            {
                arrAnalogSensor[i] = new AnalogSensor(i, "","", aMinRange, aMaxRange, aRes);            
            }

            //Creating digital sensors
            for (int d = 0; d < dSensorCount; d++)
            {
                arrDigSensor[d] = new DigitalSensor(d, "");
            }
        }



        private void btnLogToFile_Click(object sender, RoutedEventArgs e)
        {
            lstViewLogVals.Items.Clear();
            lstViewDigLogVals.Items.Clear();
            txtList.Clear();
            elapsedTimeLog = Convert.ToDouble(Math.Truncate(DateTime.Now.Subtract(dtLogStart).TotalSeconds));
            if (elapsedTimeLog >= logTime)
            {
                txtNextLogTime.Clear();
                dtLogStart = DateTime.Now;
                //Getting and storing analog sensor values
                logFile.appendToFile(DateTime.Now.ToString(),_startOfLine:true);
                for (int j = 0; j < aSensorCount; j++)
                {
                    arrListValues[j] = arrAnalogSensor[j].GetValue();
                    lstViewLogVals.Items.Add("Sensor " + (1 + j) + " value: " + arrListValues[j].ToString() + " [V]");
                    logFile.appendToFile(filteredVal[j].ToString());
                }
                
                //Getting and storing digital sensor values
                for (int k=0; k < dSensorCount; k++)
                {
                    arrListDigValues[k] = Convert.ToInt32(arrDigSensor[k].GetValue());
                    lstViewDigLogVals.Items.Add("Dig. Sensor " + (k + 1) + " value: " +arrListDigValues[k]);
                    logFile.appendToFile(arrListDigValues[k].ToString());
                }
                logFile.appendToFile("", _endOfLine: true);
            }
            else
            {
                txtList.Text = "Required elapsed time between logging not acheived!";
                txtNextLogTime.Text = (logTime - elapsedTimeLog).ToString();
                
            }
        }

        

        private void btnReadSensVal_Click(object sender, RoutedEventArgs e)
        {
            lstView1.Items.Clear();
            lstViewDigSensVals.Items.Clear();
            lstViewFilteredVals.Items.Clear();
            txtList.Clear();
            elapsedTimeSampling = Convert.ToDouble(Math.Truncate(DateTime.Now.Subtract(dtSampStart).TotalMilliseconds));
            if (elapsedTimeSampling >= sampleTime)
            {
                txtNextLogTime.Clear();
                txtNextReadTime.Clear();
                dtSampStart = DateTime.Now;
                //Getting analog sensor values
                for (int j = 0; j < aSensorCount; j++)
                {
                    arrListValues[j] = arrAnalogSensor[j].GetValue();
                    lstView1.Items.Add("Sensor " + (1 + j) + " value: " + arrListValues[j].ToString() + " [V]");
                    filteredVal = filter.FilterValues(arrListValues[j]);
                    lstViewFilteredVals.Items.Add("Sensor " + (1 + j) + " filtered value: " + filteredVal[j]);
                }
                
                //Getting digital sensor values
                for (int k = 0; k < dSensorCount; k++)
                {
                    lstViewDigSensVals.Items.Add("Dig. Sensor " + (k + 1) + " value: " + arrDigSensor[k].GetValue());
                }
            }
            else
            {
                txtList.Text = "Required sampling time not acheived!";
                txtNextReadTime.Text = ((sampleTime - elapsedTimeSampling) / 1000.0).ToString();
            }
            txtTestTextBox.Text = scaleSensor2.ScaleValue(arrListValues[2]).ToString();
        }

        private void mnuFileExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mnuHelpSampling_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The system is available for sampling every " + sampleTime/1000 + " seconds","About Sampling");
        }

        private void mnuHelpLogging_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The system is available for sampling every " + logTime + " seconds \nLog file path: \n"+path, "About Logging");
        }
    }
}
