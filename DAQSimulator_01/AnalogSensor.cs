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
        public AnalogSensor(int _sensorId, string _name, string _type, string _measurand, string _txtPos, int _minVolt, int _maxVolt, int _res)
            : base(_sensorId, _name, _type,_measurand,_txtPos,_minVolt,_maxVolt,_res)
        {
            name = _name; //assigns name
            type = _type; //Assigns type
            measurand = _measurand; //Assigns measureand
            txtPos = _txtPos; // Assigns txtPos
            sensorId = _sensorId; //Assigngs sensorId
            minValue = _minVolt; //V
            maxValue = _maxVolt; //V
            res = _res; //resolution
            rnd = new Random(sensorId); //Instanciate a new random
            minValue = _minVolt; //V
            maxValue = _maxVolt; //V
        }
    }
}
