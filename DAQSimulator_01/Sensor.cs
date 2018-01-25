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
        Random rnd;

        public Sensor(string _name, string _type, string _measurand, string _txtPos)
        {
            name = _name;
            type = _type;
            measurand = _measurand;
            txtPos = _txtPos;
            sValue = 0;
            //countSensor++;
            sensorId = 0;
            rnd = new Random(sensorId);
        }

        public int GetValue()
        {
            sValue = SimSensor();
            return sValue;
        }

        private int SimSensor()
        {
           return rnd.Next(0,100);
        }
        
    }
}
