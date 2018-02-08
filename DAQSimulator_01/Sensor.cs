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
    /// Purpose: Class for sensor objects
    /// 
    /// ///////////////////////////////////////////////////////////////////////////////
    /// </summary>
    class Sensor
    {
        /// <summary>
        /// Object variables
        /// </summary>
        protected string name;
        protected string type;
        protected string measurand;
        protected double sValue;
        protected string txtPos;
        protected int sensorId;
        protected Random rnd;
        private double lastValue;
        protected int res;

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
        public Sensor()
        {

        }

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////
        /// 
        /// Created by: Andreas Rege
        /// V1.0
        /// Date: 2018-02-08
        /// 
        /// Purpose: Constructor with arguments(params)
        /// 
        /// ///////////////////////////////////////////////////////////////////////////////
        /// </summary>
        public Sensor(int _sensorId, string _type, string _measurand, string _txtPos, int _res)
        {
            name = _type+_sensorId.ToString(); //assigns name
            type = _type; //Assigns type
            measurand = _measurand; //Assigns measureand
            txtPos = _txtPos; // Assigns txtPos
            sensorId = _sensorId; //Assigngs sensorId
            res = _res;
            rnd = new Random(sensorId); //Instanciate a new random
        }

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////
        /// 
        /// Created by: Andreas Rege
        /// V1.0
        /// Date: 2018-02-08
        /// 
        /// Purpose: Function/Method to get value from sensor
        /// 
        /// ///////////////////////////////////////////////////////////////////////////////
        /// </summary>
        public virtual double GetValue()
        {
            sValue = SimSensor(res);
            return sValue;
        }

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////
        /// 
        /// Created by: Andreas Rege
        /// V1.0
        /// Date: 2018-02-08
        /// 
        /// Purpose: Function/Method that generates a random number to simulate a sensor value
        /// 
        /// ///////////////////////////////////////////////////////////////////////////////
        /// </summary>
        protected int SimSensor(int _resolution)
        {
            
            return rnd.Next(_resolution);
        }

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////
        /// 
        /// Created by: Andreas Rege
        /// V1.0
        /// Date: 2018-02-08
        /// 
        /// Purpose: Property to store and return last value from sensor
        /// 
        /// ///////////////////////////////////////////////////////////////////////////////
        /// </summary>
        public double LastValue
        {
            get { return lastValue; }
            protected set { lastValue = value; }
        }

    }
}
