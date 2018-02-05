using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAQSimulator_01
{
    class DigitalSensor : Sensor
    {
        public DigitalSensor()
        {
            //sensorId = _sensorId;
        }
        public DigitalSensor(int _sensorId, string _name, string _type, string _measurand, string _txtPos, int _min, int _max, int _res)
            : base(_sensorId, _name, _type, _measurand, _txtPos, _min, _max, _res)
        {
            name = _name; //assigns name
            type = _type; //Assigns type
            txtPos = _txtPos; // Assigns txtPos
            sensorId = _sensorId; //Assigngs sensorId
            minValue = _min;
            maxValue = _max;
            res = _res;
            rnd = new Random(sensorId); //Instanciate a new random
        }
    }
}
