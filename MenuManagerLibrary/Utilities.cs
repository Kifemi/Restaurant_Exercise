using System;
using System.Collections.Generic;
using System.Text;

namespace MenuManagerLibrary
{
    public class Utilities
    {
        public static string TrimString()
        {
            return null;
        }

        public void PrintHelp()
        {

        }


        public static List<double> SortListDouble(List<double> list)
        {
            List<double> sortedList = new List<double>();
            List<double> tempList = new List<double>(list);
            int minIndex = 0;
            double minValue;
            int numberOfIterations = tempList.Count;

            for (int i = 0; i < numberOfIterations; i++)
            {
                minValue = tempList[0];
                minIndex = 0;

                for (int j = 1; j < tempList.Count; j++)
                {
                    if(minValue > tempList[j])
                    {
                        minValue = tempList[j];
                        minIndex = j;
                    }
                }

                sortedList.Add(tempList[minIndex]);
                tempList.RemoveAt(minIndex);
            }

            return sortedList;
        }

      


    }
}
