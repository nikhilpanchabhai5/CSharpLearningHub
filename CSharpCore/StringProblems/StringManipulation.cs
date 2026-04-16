using CSharpLearningHubCore.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpLearningHub.StringProblems
{
    public class StringManipulation : IProblem
    {
        public string ProblemName => "String Manipulation";
        public string Description => "Various string operations";

        public void Display()
        {
            Console.WriteLine($"\n===== {ProblemName} =====");
            Console.WriteLine(Description);
            // Your implementation here
        }
    }
}
