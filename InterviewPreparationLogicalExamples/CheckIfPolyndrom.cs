

namespace InterviewPreparationLogicalExamples
{
    internal class CheckIfPolyndrom
    {
        public CheckIfPolyndrom()
        {
            Console.WriteLine("Enter string:");
            string inputString = Console.ReadLine();
            string reversed = new string(inputString.Reverse().ToArray());
            if (inputString == reversed)
                Console.WriteLine("It is polyndrom");
            else
                Console.WriteLine("Not a Polyndrom");

        }
    }
}
