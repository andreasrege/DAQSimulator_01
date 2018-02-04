using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAQSimulator_01
{
    class Filter
    {
        List<double[]> MA_FilterList = new List<double[]>();
        double values;
        double[] filteredValue = new double[5];
        int filterSize = 5;
        double[,] sampledValues = new double[5, 7];
        double[] totalVal = new double[5];
        int index1 = 0;
        int index2 = 0;

        bool enableFiltering=false;


        public void AddToMAFList(double _values)
        {
            values = _values;
            //MA_FilterList.Add(values);
            //FilterValues(MA_FilterList);
            FilterValues(values);


        }

        public double[] FilterValues(double _RawValues)
        {
            sampledValues[index1, index2] = _RawValues;
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
                for (int f=0; f<filterSize;f++)
                {
                    for (int g=0; g<filterSize; g++)
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
