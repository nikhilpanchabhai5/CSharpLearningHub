using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewPreparationLogicalExamples
{
    internal class DuplicateCharInString
    {
        public DuplicateCharInString() {

            Console.WriteLine("Enter string:");
            string input = Console.ReadLine();

            var duplicates = input
                .GroupBy(c => c)
                .Where(c => c.Count() > 1)
                .Select(g=>new
                {
                    charrecter = g.Key,
                    count = g.Count()
                });

            foreach( var item in duplicates)
            {
                Console.WriteLine($"{item.charrecter}: {item.count}");
            }                
        
        }
        
    }
}
