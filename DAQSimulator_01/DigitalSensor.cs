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
    /// Purpose: Class for Digital Sensor objects that inherits from Sensor class
    /// 
    /// ///////////////////////////////////////////////////////////////////////////////
    /// </summary>
    class DigitalSensor : Sensor
    {
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
        public DigitalSensor()
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
        public DigitalSensor(int _sensorId, string _txtPos)
            : base(_sensorId, "di", "", _txtPos, _res:2)
        {

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
        /// ///////////
        public override double GetValue()
        {
            LastValue = base.GetValue();
            return LastValue;
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
            strDispLine += LastValue.ToString();
            return strDispLine;
        }
    }
}
