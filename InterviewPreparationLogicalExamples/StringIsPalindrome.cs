using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewPreparationLogicalExamples
{
    internal class StringIsPalindrome
    {
        public StringIsPalindrome() { 
            //Console.WriteLine("Enter string:");
            string inputString = "nitin";
            inputString = inputString.ToLower().Replace(" ", "");
            Console.WriteLine(inputString);
            int i = 0;
            int j = inputString.Length - 1;
            bool isPalindrome = true;
            while (i < j)
            {
                if (inputString[i] != inputString[j])
                {
                    isPalindrome = false;
                    break;
                }
                i++;
            }
            Console.WriteLine(inputString);
            if (isPalindrome)
                Console.WriteLine("String is a palindrome");
            else
                Console.WriteLine("String is not palindrome");

        }
    }
}
