﻿using System;
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
        public AnalogSensor(int _sensorId, string _name, string _type, string _measurand, string _txtPos, int _minVolt, int _maxVolt)
        {
            name = _name; //assigns name
            type = _type; //Assigns type
            measurand = _measurand; //Assigns measureand
            txtPos = _txtPos; // Assigns txtPos
            sensorId = _sensorId; //Assigngs sensorId
            rnd = new Random(sensorId); //Instanciate a new random
            minVolt = _minVolt; //V
            maxVolt = _maxVolt; //V
        }
    }
}
