using System;
using System.Collections.Generic;
using System.Text;

namespace MenuManagerLibrary
{
    public class Utilities
    {
        public static string TrimString(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            return str.Trim();
        }

        public static string ToLowerCase(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            return str.ToLower();
        }

        public static string UpperCaseFirstLetter(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            // convert to char array of the string
            char[] letters = str.ToCharArray();
            // upper case the first char
            letters[0] = char.ToUpper(letters[0]);
            // return the array made of the new char array
            return new string(letters);
        }

        public void PrintHelp()
        {

        }     

    }
}
