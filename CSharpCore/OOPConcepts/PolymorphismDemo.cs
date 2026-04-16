using CSharpLearningHubCore.Core;
using System;
using System.Collections.Generic;

namespace CSharpLearningHubCore.OOPConcepts
{
    public class PolymorphismDemo : IProblem
    {
        public string ProblemName => "Polymorphism Demo - Complete Guide";

        public string Description =>
            "Polymorphism is the ability of an object to take on many forms.\n" +
            "In C#, we can achieve polymorphism using:\n" +
            "1. Method Overloading - Same method name, different parameters\n" +
            "2. Method Overriding - Child class replaces parent's virtual method\n" +
            "3. Method Shadowing/Hiding - Child class hides parent's method using 'new'\n" +
            "4. Interfaces - Multiple implementations of same contract";

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║     " + ProblemName + "     ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝\n");

            Console.WriteLine(Description);
            Console.WriteLine("\n" + new string('=', 60) + "\n");

            // 1. Method Overloading
            Console.WriteLine("1️⃣  METHOD OVERLOADING (Same name, Different parameters)");
            Console.WriteLine(new string('-', 60));
            DemoMethodOverloading();

            Console.WriteLine("\n" + new string('=', 60) + "\n");

            // 2. Method Overriding
            Console.WriteLine("2️⃣  METHOD OVERRIDING (Using 'override' keyword)");
            Console.WriteLine(new string('-', 60));
            DemoMethodOverriding();

            Console.WriteLine("\n" + new string('=', 60) + "\n");

            // 3. Method Shadowing/Hiding
            Console.WriteLine("3️⃣  METHOD SHADOWING/HIDING (Using 'new' keyword)");
            Console.WriteLine(new string('-', 60));
            DemoMethodShadowing();

            Console.WriteLine("\n" + new string('=', 60) + "\n");

            // 4. Comparison: Override vs Shadowing
            Console.WriteLine("4️⃣  COMPARISON: Method Overriding vs Method Shadowing");
            Console.WriteLine(new string('-', 60));
            DemoOverrideVsShadowing();

            Console.WriteLine("\n" + new string('=', 60) + "\n");

            // 5. Interface Polymorphism
            Console.WriteLine("5️⃣  INTERFACE POLYMORPHISM");
            Console.WriteLine(new string('-', 60));
            DemoInterfacePolymorphism();

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        #region 1. Method Overloading
        private void DemoMethodOverloading()
        {
            Console.WriteLine("\n📌 Example: Calculator with different parameter types\n");

            var calculator = new Calculator();

            // Overload 1: int parameters
            int resultInt = calculator.Add(5, 10);
            Console.WriteLine($"   Add(5, 10) [int] = {resultInt}");

            // Overload 2: double parameters
            double resultDouble = calculator.Add(5.5, 10.5);
            Console.WriteLine($"   Add(5.5, 10.5) [double] = {resultDouble}");

            // Overload 3: string parameters
            string resultString = calculator.Add("Hello, ", "World!");
            Console.WriteLine($"   Add(\"Hello, \", \"World!\") [string] = {resultString}");

            // Overload 4: three parameters
            int resultThree = calculator.Add(5, 10, 15);
            Console.WriteLine($"   Add(5, 10, 15) [three ints] = {resultThree}");

            Console.WriteLine("\n✓ BENEFITS:");
            Console.WriteLine("  • Same method name for similar operations");
            Console.WriteLine("  • Compiler resolves based on parameter types at COMPILE TIME");
            Console.WriteLine("  • Makes code more readable and intuitive");
        }
        #endregion

        #region 2. Method Overriding
        private void DemoMethodOverriding()
        {
            Console.WriteLine("\n📌 Example: Payment Processors using override\n");

            // Polymorphic collection - all are PaymentProcessor types
            List<PaymentProcessor> processors = new List<PaymentProcessor>
            {
                new UPIPaymentProcessor(),
                new CreditCardPaymentProcessor(),
                new NetBankingPaymentProcessor()
            };

            foreach (var processor in processors)
            {
                processor.ProcessPayment(1000);
            }

            Console.WriteLine("\n✓ HOW IT WORKS:");
            Console.WriteLine("  • Parent class uses 'virtual' keyword");
            Console.WriteLine("  • Child class uses 'override' keyword");
            Console.WriteLine("  • Method resolution happens at RUNTIME (dynamic)");
            Console.WriteLine("  • Actual method called depends on ACTUAL OBJECT type, not reference type");
        }
        #endregion

        #region 3. Method Shadowing/Hiding
        private void DemoMethodShadowing()
        {
            Console.WriteLine("\n📌 Example: Method Shadowing using 'new' keyword\n");

            // Parent class reference pointing to child object
            AnimalBase animalRef = new DogShadowing();
            DogShadowing dogRef = new DogShadowing();

            Console.WriteLine("   Using AnimalBase reference:");
            animalRef.MakeSound();  // Calls AnimalBase.MakeSound()

            Console.WriteLine("\n   Using DogShadowing reference:");
            dogRef.MakeSound();     // Calls DogShadowing.MakeSound()

            Console.WriteLine("\n💡 KEY DIFFERENCE:");
            Console.WriteLine("  • With 'new' keyword: method hiding, not replacement");
            Console.WriteLine("  • Method resolution happens at COMPILE TIME based on reference type");
            Console.WriteLine("  • NOT considered true polymorphism (not recommended)");
            Console.WriteLine("  • If called through parent reference, parent method is called");
            Console.WriteLine("  • If called through child reference, child method is called");
        }
        #endregion

        #region 4. Override vs Shadowing Comparison
        private void DemoOverrideVsShadowing()
        {
            Console.WriteLine("\n📌 Comparing: Override vs Shadowing\n");

            Console.WriteLine("   Parent reference to OVERRIDE child:");
            AnimalBase animalOverride = new DogOverride();
            animalOverride.Jump();  // Calls DogOverride.Jump() - True polymorphism!

            Console.WriteLine("\n   Parent reference to SHADOW child:");
            AnimalBase animalShadow = new DogShadowing();
            animalShadow.MakeSound();  // Calls AnimalBase.MakeSound() - NOT child method!

            Console.WriteLine("\n\n✓ COMPARISON TABLE:");
            Console.WriteLine("┌─────────────────────────────────────────────────────────┐");
            Console.WriteLine("│ Aspect              │ Override (virtual) │ Shadowing (new) │");
            Console.WriteLine("├─────────────────────────────────────────────────────────┤");
            Console.WriteLine("│ Keyword             │ override           │ new             │");
            Console.WriteLine("│ Parent must be      │ virtual            │ normal method   │");
            Console.WriteLine("│ Resolution          │ Runtime (dynamic)  │ Compile time    │");
            Console.WriteLine("│ Polymorphism        │ YES ✓              │ NO ✗            │");
            Console.WriteLine("│ Parent ref behavior │ Calls child method │ Calls parent    │");
            Console.WriteLine("│ Recommended         │ YES ✓              │ NO ✗ (avoid)    │");
            Console.WriteLine("└─────────────────────────────────────────────────────────┘");
        }
        #endregion

        #region 5. Interface Polymorphism
        private void DemoInterfacePolymorphism()
        {
            Console.WriteLine("\n📌 Example: Multiple implementations of same interface\n");

            List<IVehicle> vehicles = new List<IVehicle>
            {
                new Car(),
                new Bike(),
                new Truck()
            };

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"\n   {vehicle.GetType().Name}:");
                vehicle.Start();
                vehicle.Drive();
                vehicle.Stop();
            }

            Console.WriteLine("\n✓ BENEFITS OF INTERFACE POLYMORPHISM:");
            Console.WriteLine("  • One interface, multiple implementations");
            Console.WriteLine("  • Loose coupling - depend on abstractions, not concretions");
            Console.WriteLine("  • Easy to add new implementations without changing existing code");
            Console.WriteLine("  • True polymorphism - method resolution at runtime");
        }
        #endregion
    }

    #region Overloading Classes
    public class Calculator
    {
        // Overload 1: Two integers
        public int Add(int a, int b)
        {
            return a + b;
        }

        // Overload 2: Two doubles
        public double Add(double a, double b)
        {
            return a + b;
        }

        // Overload 3: Two strings
        public string Add(string a, string b)
        {
            return a + b;
        }

        // Overload 4: Three integers
        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }
    }
    #endregion

    #region Overriding Classes
    public abstract class PaymentProcessor
    {
        // Virtual method - can be overridden
        public virtual void ProcessPayment(double amount)
        {
            Console.WriteLine("   [Base] Processing payment...");
        }
    }

    public class UPIPaymentProcessor : PaymentProcessor
    {
        // Override - replaces parent method
        public override void ProcessPayment(double amount)
        {
            Console.WriteLine($"   [UPI] Processing UPI payment of ₹{amount}");
            Console.WriteLine($"   [UPI] Transaction ID: UPI{DateTime.Now.Ticks}");
        }
    }

    public class CreditCardPaymentProcessor : PaymentProcessor
    {
        // Override - replaces parent method
        public override void ProcessPayment(double amount)
        {
            Console.WriteLine($"   [CC] Processing Credit Card payment of ₹{amount}");
            Console.WriteLine($"   [CC] Charge interest: {amount * 0.02}");
        }
    }

    public class NetBankingPaymentProcessor : PaymentProcessor
    {
        // Override - replaces parent method
        public override void ProcessPayment(double amount)
        {
            Console.WriteLine($"   [NB] Processing Net Banking payment of ₹{amount}");
            Console.WriteLine($"   [NB] OTP verification required");
        }
    }
    #endregion

    #region Shadowing Classes
    public class AnimalBase
    {
        public virtual void Jump()
        {
            Console.WriteLine("   [Animal] Jumping...");
        }

        public void MakeSound()  // Note: NOT virtual
        {
            Console.WriteLine("   [Animal] Making generic sound...");
        }
    }

    public class DogOverride : AnimalBase
    {
        // Override - true polymorphism
        public override void Jump()
        {
            Console.WriteLine("   [Dog] Jumping high with all four legs!");
        }
    }

    public class DogShadowing : AnimalBase
    {
        // Shadow - using 'new' keyword (NOT true polymorphism)
        public new void MakeSound()
        {
            Console.WriteLine("   [Dog] Woof! Woof!");
        }
    }
    #endregion

    #region Interface Polymorphism Classes
    public interface IVehicle
    {
        void Start();
        void Drive();
        void Stop();
    }

    public class Car : IVehicle
    {
        public void Start()
        {
            Console.WriteLine("      🔑 Car engine started");
        }

        public void Drive()
        {
            Console.WriteLine("      🚗 Car is driving on road at 100 km/h");
        }

        public void Stop()
        {
            Console.WriteLine("      🛑 Car stopped with brakes");
        }
    }

    public class Bike : IVehicle
    {
        public void Start()
        {
            Console.WriteLine("      🔑 Bike engine started");
        }

        public void Drive()
        {
            Console.WriteLine("      🏍️  Bike is riding at 80 km/h");
        }

        public void Stop()
        {
            Console.WriteLine("      🛑 Bike stopped");
        }
    }

    public class Truck : IVehicle
    {
        public void Start()
        {
            Console.WriteLine("      🔑 Truck diesel engine started");
        }

        public void Drive()
        {
            Console.WriteLine("      🚚 Truck is driving cargo at 60 km/h");
        }

        public void Stop()
        {
            Console.WriteLine("      🛑 Truck stopped with air brakes");
        }
    }
    #endregion
}