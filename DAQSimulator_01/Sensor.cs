using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAQSimulator_01
{
   
    class Sensor
    {
        protected string name;
        protected string type;
        protected string measurand;
        protected int sValue;
        protected string txtPos;
        protected int sensorId;
        protected Random rnd;
        protected int minVolt;
        protected int maxVolt;


        public Sensor()
        {

        }

        public Sensor(int _sensorId, string _name, string _type, string _measurand, string _txtPos)
        {

        }

        public int GetValue(int _minVolt, int _maxVolt)
        {
            minVolt = _minVolt;
            maxVolt = _maxVolt;
            sValue = SimSensor(minVolt, maxVolt);
            return sValue;
        }

        private int SimSensor(int minVal, int maxVal)
        {
           return rnd.Next(minVal, maxVal);
        }
        
    }
}
