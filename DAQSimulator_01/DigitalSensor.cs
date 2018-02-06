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
        public DigitalSensor(int _sensorId, string _txtPos)
            : base(_sensorId, "di", "", _txtPos, _res:2)
        {

        }
    }
}
