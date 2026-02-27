using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewPreparationLogicalExamples
{
    internal class ReverseStringLinq
    {
        public ReverseStringLinq()
        {
            Console.WriteLine("Enter string:");
            string inputString = Console.ReadLine();
            //Console.WriteLine(new string(inputString.Reverse().ToArray()));

            string resversedString = "";
            for (int i = inputString.Length - 1; i >= 0; i--) 
            {
                resversedString += inputString[i];
            }
            Console.WriteLine(resversedString);


        }
    }
}
