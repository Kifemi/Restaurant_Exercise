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
            
            char[] letters = str.ToCharArray();
            
            letters[0] = char.ToUpper(letters[0]);
            
            return new string(letters);
        }

        public static string TrimInput()
        {
            string inputTrimmed = ToLowerCase(TrimString(Console.ReadLine()));
            return inputTrimmed;
        }

        //public void PrintHelp()
        //{
        //    Console.WriteLine("Commands: \n" +
        //        "\t add\n" +
        //        "\t print\n" +
        //        "\t help\n" +
        //        "\t exit");

        //    string input = TrimInput();

        //    if (input.Equals("add"))
        //    {
        //        Console.WriteLine("Add options: \n" +
        //        "\t menu --- creates new menu\n" +
        //        "\t category --- adds new category to a menu\n" +
        //        "\t dish --- adds new dish to a menu or a category\n" +
        //        "\t back --- return to previous menu");
        //    }

               
        //}     

    }
}
