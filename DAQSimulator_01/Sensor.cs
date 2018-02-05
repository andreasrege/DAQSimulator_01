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
        protected int minValue;
        protected int maxValue;
        protected Scale scaledSensVal;
        protected int res;// = Convert.ToInt32(Math.Pow(2, 22));


        public Sensor()
        {
            /*
            minValue = _min;
            maxValue = _max;
            res = _res;*/
            //scaledSensVal = new Scale(0, res, minValue, maxValue);
        }

        public Sensor(int _sensorId, string _name, string _type, string _measurand, string _txtPos,int _min, int _max, int _res)
        {
            minValue = _min;
            maxValue = _max;
            res = _res;
            scaledSensVal = new Scale(0, res, minValue, maxValue);
        }

        public double GetValue()
        {
            //minVolt = _minVolt;
            //maxVolt = _maxVolt;
            sValue = SimSensor(res);
            sValue = scaledSensVal.ScaleValue(sValue);
            return sValue;
        }

        private int SimSensor(int _resolution)
        {
            
            return rnd.Next(_resolution);
        }
        
    }
}
