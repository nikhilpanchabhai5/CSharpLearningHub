using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpLearningHubCore.Core
{
    public interface IProblem
    {
        void Display();
        string ProblemName { get; }
        string Description { get; }
    }
}
