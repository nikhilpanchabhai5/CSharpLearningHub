using InterviewPreparationLogicalExamples;

class program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Here all example of logical question given just type no below:");
            Console.WriteLine("1. Duplicate chareter in string using Linq.");
            Console.WriteLine("2. Reverse string using Linq.");
            Console.WriteLine("3. Check if string is palindrome.");
            Console.WriteLine("4. Reverse word in sentence.");
            Console.WriteLine("5. Check if palindrome using while loop.");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DuplicateCharInString running = new DuplicateCharInString();
                    break;
                case 2:
                    ReverseStringLinq run = new ReverseStringLinq();
                    break;
                case 3:
                    CheckIfPolyndrom polyndrom = new CheckIfPolyndrom();
                    break;
                case 4:
                    ReverseWordInSentence reverseWordInSentence = new ReverseWordInSentence();
                    break;
                case 5:
                    StringIsPalindrome stringIsPalindrome = new StringIsPalindrome();
                    break;
                default:
                    Console.WriteLine("Invalid input:");
                    break;
            }
            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
        }

    }
}


