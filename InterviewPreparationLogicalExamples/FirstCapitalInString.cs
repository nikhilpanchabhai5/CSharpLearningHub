using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewPreparationLogicalExamples
{
    public class FirstCapitalInString
    {
        public FirstCapitalInString() 
        {
            Console.WriteLine("Enter string with capital letter:");
            string inputString = Console.ReadLine();

            foreach ( char c in inputString)
            {
                if(char.IsUpper(c))
                {
                    Console.WriteLine(c);
                    break;
                }
            }
        }


    }
}
