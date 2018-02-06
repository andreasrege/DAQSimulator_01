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
        //Scale scaleSensor2;
       // Filter filter;
        Filter[] filter;
       // double[] filteredVal = new double[7];
        //double[] arrListValues;
        //int[] arrListDigValues;
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
        //int dRes = Convert.ToInt32(Math.Pow(2,1));

        string path = @"C:\Users\andreas\Documents\_Skole\Visual Studio code\LogFiles\log333.csv";
        bool fileExist;
        public MainWindow()
        {


            InitializeComponent();

            filter = new Filter[aSensorCount]; //creates array of filters

            logFile = new Log(path);
            fileExist = logFile.checkFileExist();

            txtList.Text = fileExist.ToString();

            arrAnalogSensor = new AnalogSensor[aSensorCount];

            arrDigSensor = new DigitalSensor[dSensorCount];

            //Creating analog sensors
            for (int i=0; i< aSensorCount; i++)
            {
                arrAnalogSensor[i] = new AnalogSensor(i, "V","", aMinRange, aMaxRange, aRes);
                filter[i] = new Filter(5);
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
                    lstViewLogVals.Items.Add(filter[j].DisplayLine(j));
                    logFile.appendToFile(filter[j].FilteredValue.ToString());
                }
                
                //Getting and storing digital sensor values
                for (int k=0; k < dSensorCount; k++)
                {
                    lstViewDigLogVals.Items.Add(arrDigSensor[k].DisplayLine());
                    logFile.appendToFile(arrDigSensor[k].LastValue.ToString());
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
                    arrAnalogSensor[j].GetValue();
                    lstView1.Items.Add(arrAnalogSensor[j].DisplayLine());
                    filter[j].AddValue(arrAnalogSensor[j].LastValue);
                    lstViewFilteredVals.Items.Add(filter[j].DisplayLine(j));
                }
                
                //Getting digital sensor values
                for (int k = 0; k < dSensorCount; k++)
                {
                    arrDigSensor[k].GetValue();
                    lstViewDigSensVals.Items.Add(arrDigSensor[k].DisplayLine());
                }
            }
            else
            {
                txtList.Text = "Required sampling time not acheived!";
                txtNextReadTime.Text = ((sampleTime - elapsedTimeSampling) / 1000.0).ToString();
            }
            //txtTestTextBox.Text = scaleSensor2.ScaleValue(arrListValues[2]).ToString();
        }

        private void mnuFileExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
