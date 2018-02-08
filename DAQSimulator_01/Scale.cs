using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAQSimulator_01
{
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////
    /// 
    /// Created by: Andreas Rege
    /// V1.0
    /// Date: 2018-02-08
    /// 
    /// Purpose: General class for linear scaling
    /// 
    /// ///////////////////////////////////////////////////////////////////////////////
    /// </summary>
    class Scale
    {
        /// <summary>
        /// Object variables
        /// </summary>
        private double minRaw, maxRaw, minScaled, maxScaled;
        public double scaledValue;

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////
        /// 
        /// Created by: Andreas Rege
        /// V1.0
        /// Date: 2018-02-08
        /// 
        /// Purpose: Constructor that takes min and max values as args
        /// 
        /// ///////////////////////////////////////////////////////////////////////////////
        /// </summary>
        public Scale(double _minRaw, double _maxRaw, double _minScaled, double _maxScaled)
        {
            minRaw = _minRaw;
            maxRaw = _maxRaw;
            minScaled = _minScaled;
            maxScaled = _maxScaled;
        }

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////
        /// 
        /// Created by: Andreas Rege
        /// V1.0
        /// Date: 2018-02-08
        /// 
        /// Purpose: Function/Method that scales an incoming value and returns 
        ///             the scaled value
        /// 
        /// ///////////////////////////////////////////////////////////////////////////////
        /// </summary>
        public double ScaleValue(double rawValue)
        {
            scaledValue = ((maxScaled - minScaled) / (maxRaw - minRaw)) * (rawValue - minRaw) + minScaled;
            return scaledValue;
        }
    }
}
