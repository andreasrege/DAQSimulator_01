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
        protected double sValue;
        protected string txtPos;
        protected int sensorId;
        protected Random rnd;
        private double lastValue;
        protected int res;


        public Sensor()
        {

        }

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

        public virtual double GetValue()
        {
            sValue = SimSensor(res);
            return sValue;
        }

        protected int SimSensor(int _resolution)
        {
            
            return rnd.Next(_resolution);
        }

        public double LastValue
        {
            get { return lastValue; }
            protected set { lastValue = value; }
        }

    }
}
