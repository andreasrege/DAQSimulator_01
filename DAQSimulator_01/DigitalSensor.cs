using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAQSimulator_01
{
    class DigitalSensor : Sensor
    {
        public DigitalSensor(int _sensorId)
        {
            //sensorId = _sensorId;
        }
        public DigitalSensor(int _sensorId, string _name, string _type, string _txtPos)
        {
            name = _name; //assigns name
            type = _type; //Assigns type
            txtPos = _txtPos; // Assigns txtPos
            sensorId = _sensorId; //Assigngs sensorId
            rnd = new Random(sensorId); //Instanciate a new random
        }
    }
}
