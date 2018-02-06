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

        public override double GetValue()
        {
            LastValue = base.GetValue();
            return LastValue;
        }

        

        public string DisplayLine()
        {
            string strDispLine = "Sensor ";
            strDispLine += name;
            strDispLine += " value: ";
            strDispLine += LastValue.ToString();
            return strDispLine;
        }
    }
}
