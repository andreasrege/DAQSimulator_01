using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAQSimulator_01
{
    class AnalogSensor : Sensor
    {
        private Scale scaledSensVal;
        private int minValue;
        private int maxValue;
        public AnalogSensor(int _sensorId)
        {
            //sensorId = _sensorId;
        }
        public AnalogSensor(int _sensorId, string _measurand, string _txtPos, int _min, int _max, int _res)
            : base(_sensorId, "ai" ,_measurand,_txtPos,_res)
        {
            minValue = _min;
            maxValue = _max;
            scaledSensVal = new Scale(0, res, minValue, maxValue);
            
        }

        public override double GetValue()
        {
            double tmp;
            tmp = base.GetValue();
            tmp = scaledSensVal.ScaleValue(tmp);
            return tmp;
        }
    }
}
