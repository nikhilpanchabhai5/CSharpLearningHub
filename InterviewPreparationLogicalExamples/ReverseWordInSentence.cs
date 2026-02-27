using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewPreparationLogicalExamples
{
    internal class ReverseWordInSentence
    {
        public ReverseWordInSentence() 
        {
            Console.WriteLine("Enter your sentence:");
            string inputString = Console.ReadLine();
            string[] words = inputString.Split(' ');
            StringBuilder stringBuilder = new StringBuilder();            
            for(int i =words.Length-1;  i >= 0; i--)
            {
                if (stringBuilder.Length > 0)
                    stringBuilder.Append(' ');
                stringBuilder.Append(words[i]);
            }                
            Console.WriteLine(stringBuilder.ToString());

            var reversedWordSentence = inputString.Split(' ')
                .Select(word => word.Reverse().ToArray());

        }
    }
}
