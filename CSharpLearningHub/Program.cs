using CSharpLearningHubCore.Core;           // ✅ Add this
using CSharpLearningHub.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Automatically discover all problems!
        var problemsByCategory = ProblemDiscovery.DiscoverProblems();

        while (true)
        {
            Console.Clear();
            DisplayMenu(problemsByCategory);

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 0)
                {
                    Console.WriteLine("Exiting...");
                    break;
                }

                IProblem selected = GetProblemByChoice(problemsByCategory, choice);
                if (selected != null)
                {
                    selected.Display();
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number!");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    static void DisplayMenu(Dictionary<string, List<IProblem>> categories)
    {
        Console.WriteLine("╔════════════════════════════════════════════════════╗");
        Console.WriteLine("║  C# Logical Practice - Interview Preparation      ║");
        Console.WriteLine("╚════════════════════════════════════════════════════╝\n");

        int choiceNumber = 1;
        var allProblems = new Dictionary<int, IProblem>();

        // Display by category
        foreach (var category in categories.OrderBy(c => c.Key))
        {
            Console.WriteLine($"\n┌─ {category.Key} ─────────────────────────────────┐");

            foreach (var problem in category.Value.OrderBy(p => p.ProblemName))
            {
                Console.WriteLine($"│ {choiceNumber,2}. {problem.ProblemName}");
                allProblems[choiceNumber] = problem;
                choiceNumber++;
            }

            Console.WriteLine("└─────────────────────────────────────────────────┘");
        }

        Console.WriteLine($"\n0. Exit");
        Console.Write($"\nTotal Problems Available: {allProblems.Count}");
        Console.Write("\nEnter your choice: ");

        // Store for later retrieval
        _allProblems = allProblems;
    }

    static Dictionary<int, IProblem> _allProblems;

    static IProblem GetProblemByChoice(Dictionary<string, List<IProblem>> categories, int choice)
    {
        int counter = 1;
        foreach (var category in categories.OrderBy(c => c.Key))
        {
            foreach (var problem in category.Value.OrderBy(p => p.ProblemName))
            {
                if (counter == choice)
                    return problem;
                counter++;
            }
        }
        return null;
    }
}