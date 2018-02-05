using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAQSimulator_01
{
    class Filter
    {
        List<double> MA_FilterList = new List<double>(5);
        double values;
        double[] filteredValue = new double[7];
        int filterSize = 5;
        int numSensors = 7;
        double[,] sampledValues = new double[5, 7];
        double[] totalVal = new double[7];
        int index1 = 0;
        int index2 = 0;

        bool enableFiltering=false;


       /* public double[] AddToMAFList(double _values)
        {
            values = _values;
            FilterValues(values);
            return 
        }*/

        public double[] FilterValues(double _RawValues)
        {
            sampledValues[index1, index2] = _RawValues;
            //MA_FilterList.Add(_RawValues);
            /*
            for (int m=0; m<sampledValues.Length;m++)
            {
                totalVal += sampledValues[m];
            }
            filteredValue = totalVal/sampledValues.Length;*/
            index2++;
            if (index2>=7)
            {
                index2 = 0;
                index1++;
            }
            if (index1 >= 5)
            {
                index1 = 0;
                enableFiltering = true;
            }
            if (enableFiltering)
            {
                /*
                foreach (int element in filteredValue)
                {
                    filteredValue[element] = 0;
                }*/
                int h = 0;
                Array.Clear(totalVal,h ,7);
                //Array.Clear(totalVal, index2, 5);
                for (int f=0; f<numSensors;f++)
                {
                    for (int g=0; g <= filterSize-1; g++)
                    {
                        totalVal[f] += sampledValues[g, f];
                    }
                    filteredValue[f] = totalVal[f] / filterSize;
                }
            }
            return filteredValue;
        }
    }
}
