using CSharpLearningHubCore.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpLearningHub.Utilities
{
    public static class ProblemDiscovery
    {
        /// <summary>
        /// Automatically finds all classes implementing IProblem
        /// Groups them by namespace/category
        /// </summary>
        public static Dictionary<string, List<IProblem>> DiscoverProblems()
        {
            var problems = new Dictionary<string, List<IProblem>>();

            // Get all types from the assembly
            var assembly = typeof(IProblem).Assembly;
            var problemTypes = assembly.GetTypes()
                .Where(t => typeof(IProblem).IsAssignableFrom(t) &&
                            !t.IsInterface &&
                            !t.IsAbstract)
                .OrderBy(t => t.FullName);

            foreach (var type in problemTypes)
            {
                // Extract category from namespace
                // e.g., "InterviewPreparationLogicalExamples.StringProblems" → "String Problems"
                string category = ExtractCategory(type.Namespace);

                if (!problems.ContainsKey(category))
                {
                    problems[category] = new List<IProblem>();
                }

                // Create instance and add to list
                var instance = (IProblem)Activator.CreateInstance(type);
                problems[category].Add(instance);
            }

            return problems;
        }

        /// <summary>
        /// Converts namespace to readable category
        /// "StringProblems" → "String Problems"
        /// "OOPConcepts" → "OOP Concepts"
        /// </summary>
        private static string ExtractCategory(string fullNamespace)
        {
            if (string.IsNullOrEmpty(fullNamespace))
                return "Other";

            // Get last part of namespace
            var parts = fullNamespace.Split('.');
            string lastPart = parts[parts.Length - 1];

            // Insert spaces before capital letters
            string readable = System.Text.RegularExpressions.Regex.Replace(
                lastPart,
                "([a-z])([A-Z])",
                "$1 $2"
            );

            return readable;
        }
    }
}
