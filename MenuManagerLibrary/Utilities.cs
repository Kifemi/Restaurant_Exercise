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
            int minIndex = 0;
            double minValue;
            int numberOfIterations = list.Count;

            for (int i = 0; i < numberOfIterations; i++)
            {
                minValue = list[0];
                minIndex = 0;

                for (int j = 1; j < list.Count; j++)
                {
                    if(minValue > list[j])
                    {
                        minValue = list[j];
                        minIndex = j;
                    }
                }

                sortedList.Add(list[minIndex]);
                list.RemoveAt(minIndex);
            }

            return sortedList;
        }

      


    }
}
