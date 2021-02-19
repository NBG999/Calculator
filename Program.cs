using System;

namespace ConsoleProject
{
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not-a-number" which we use if an operation, such as division, could result in an error.

            // Use a switch statement to do the math.
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Display title as the C# console calculator app.
            Console.WriteLine("LA CALCULADORA\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                // Declare variables and set to empty.
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // Ask the user to type the first number.
                Console.Write("POSSA UN NUMERO I DONA A ENTER: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("AIXÒ NO ES UN NÚMERO VALID, POSSA UN NOMBRE NATURAL: ");
                    numInput1 = Console.ReadLine();
                }

                // Ask the user to type the second number.
                Console.Write("POSSA UN ALTRE NUMERO I DONA A ENTER: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("AIXÒ NO ES UN NÚMERO VALID, POSSA UN NOMBRE NATURAL: ");
                    numInput2 = Console.ReadLine();
                }

                // Ask the user to choose an operator.
                Console.WriteLine("ESCOLLEIX UNA OPERACIÓ D'AQUESTA LLISTA:");
                Console.WriteLine("\ta - SUMA");
                Console.WriteLine("\ts - RESTA");
                Console.WriteLine("\tm - MULTIPILCACIÓ");
                Console.WriteLine("\td - DIVISIÓ");
                Console.Write("LA TEVA RESPOSTA? ");

                string op = Console.ReadLine();

                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("AIXÓ ES MATEMATICAMENT ERRONI.\n");
                    }
                    else Console.WriteLine("EL TEU RESULTAT: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("OH, NO! UNA EXEPCIÓ HA OCURRIT, TORNA A PROBAR.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing.
                Console.Write("CLICA 'N' PER SORTIR O ENTER PER SEGUIR: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing.
            }
            return;
        }
    }
}
