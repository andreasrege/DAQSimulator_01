using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAQSimulator_01
{
    class AnalogSensor : Sensor
    {
        public AnalogSensor(int _sensorId)
        {
            //sensorId = _sensorId;
        }
        public AnalogSensor(int _sensorId, string _name, string _type, string _measurand, string _txtPos, double _minVolt, double _maxVolt)
        {
            name = _name;
            type = _type;
            measurand = _measurand;
            txtPos = _txtPos;
            sensorId = _sensorId;
            rnd = new Random(sensorId);
            minVolt = _minVolt; //V
            maxVolt = _maxVolt; //V
        }
    }
}
