using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAQSimulator_01
{
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////
    /// 
    /// Created by: Andreas Rege
    /// V1.0
    /// Date: 2018-02-08
    /// 
    /// Purpose: Class for analog sensors, that inherits from Sensor class
    /// 
    /// ///////////////////////////////////////////////////////////////////////////////
    /// </summary>
    class AnalogSensor : Sensor
    {
        /// <summary>
        /// Object variables
        /// </summary>
        private Scale scaledSensVal;
        private int minValue;
        private int maxValue;


        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////
        /// 
        /// Created by: Andreas Rege
        /// V1.0
        /// Date: 2018-02-08
        /// 
        /// Purpose: Default constructor
        /// 
        /// ///////////////////////////////////////////////////////////////////////////////
        /// </summary>
        public AnalogSensor(int _sensorId)
        {
            //sensorId = _sensorId;
        }

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////
        /// 
        /// Created by: Andreas Rege
        /// V1.0
        /// Date: 2018-02-08
        /// 
        /// Purpose: Constructor that inherits parameters/arguments from base class Sensor
        /// 
        /// ///////////////////////////////////////////////////////////////////////////////
        /// </summary>
        public AnalogSensor(int _sensorId, string _measurand, string _txtPos, int _min, int _max, int _res)
            : base(_sensorId, "ai" ,_measurand,_txtPos,_res)
        {
            minValue = _min;
            maxValue = _max;
            
            scaledSensVal = new Scale(0, res, minValue, maxValue);
            
        }

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////
        /// 
        /// Created by: Andreas Rege
        /// V1.0
        /// Date: 2018-02-08
        /// 
        /// Purpose: Function/Method to get value from sensor, scales it returns it
        /// 
        /// ///////////////////////////////////////////////////////////////////////////////
        /// </summary>
        public override double GetValue()
        {
            double tmp;
            tmp = base.GetValue();
            tmp = scaledSensVal.ScaleValue(tmp);
            LastValue = tmp;
            return tmp;
        }

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////
        /// 
        /// Created by: Andreas Rege
        /// V1.0
        /// Date: 2018-02-08
        /// 
        /// Purpose: Function/Method to combine info to a text string 
        /// 
        /// ///////////////////////////////////////////////////////////////////////////////
        /// </summary>
        public string DisplayLine()
        {
            string strDispLine = "Sensor ";
            strDispLine += name;
            strDispLine += " value: ";
            strDispLine += LastValue.ToString("F3");
            strDispLine += " ["+measurand+ "]";
            return strDispLine;
        }
    }
}
