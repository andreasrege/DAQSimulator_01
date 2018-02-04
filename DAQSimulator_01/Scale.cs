using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAQSimulator_01
{
    class Scale
    {
        private double minRaw, maxRaw, minScaled, maxScaled;
        double scaledValue;

        public Scale(double _minRaw, double _maxRaw, double _minScaled, double _maxScaled)
        {
            minRaw = _minRaw;
            maxRaw = _maxRaw;
            minScaled = _minScaled;
            maxScaled = _maxScaled;
        }
        public double ScaleValue(double rawValue)
        {
            scaledValue = ((maxScaled - minScaled) / (maxRaw - minRaw)) * (rawValue - minRaw) + minScaled;
            return scaledValue;
        }
    }
}
