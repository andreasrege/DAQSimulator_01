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
        
        
        protected int res;// = Convert.ToInt32(Math.Pow(2, 22));


        public Sensor()
        {
            /*
            minValue = _min;
            maxValue = _max;
            res = _res;*/
            //scaledSensVal = new Scale(0, res, minValue, maxValue);
        }

        public Sensor(int _sensorId, string _type, string _measurand, string _txtPos, int _res)
        {
            name = _type+_sensorId.ToString(); //assigns name
            type = _type; //Assigns type
            measurand = _measurand; //Assigns measureand
            txtPos = _txtPos; // Assigns txtPos
            sensorId = _sensorId; //Assigngs sensorId
            //minValue = _min; //V
            //maxValue = _max; //V
            res = _res; //resolution
            rnd = new Random(sensorId); //Instanciate a new random

            //minValue = _min;
            //maxValue = _max;
            //res = _res;
            //scaledSensVal = new Scale(0, res, minValue, maxValue);
        }

        public virtual double GetValue()
        {
            //minVolt = _minVolt;
            //maxVolt = _maxVolt;
            sValue = SimSensor(res);
            //sValue = scaledSensVal.ScaleValue(sValue);
            return sValue;
        }

        protected int SimSensor(int _resolution)
        {
            
            return rnd.Next(_resolution);
        }
        
    }
}
