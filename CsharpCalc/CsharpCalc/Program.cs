namespace CsharpCalc
{
    internal class Program
    {
        public static void Main()
        {
            do
            {
                Console.Write("Enter first number: ");
                string? num1Str = Console.ReadLine();

                Console.Write("Enter operation (A-Add, S-Subtract, M-Multiply, D-Divide): ");
                string? operation = Console.ReadLine();

                Console.Write("Enter second number: ");
                string? num2Str = Console.ReadLine();

                int? result = Calculate(num1Str, operation, num2Str);

                if (result != null)
                {
                    Console.WriteLine("Result is: " + result);
                }
                else
                {
                    Console.WriteLine($"Could not calculate {num1Str} {operation} {num2Str}");
                }

                Console.WriteLine();
            } while (true);
        }

        private static int? Calculate(string? num1Str, string? operation, string? num2Str)
        {
            int? result = null;

            // check inputs are valid

            int? num1 = null;
            if (int.TryParse(num1Str, out int number1))
            {
                num1 = number1;
            }

            int? num2 = null;
            if (int.TryParse(num2Str, out int number2))
            {
                num2 = number2;
            }

            switch (operation)
            {
                case "A":
                case "a":
                    result = num1 + num2;
                    break;

                case "B":
                case "b":
                    result = num1 - num2;
                    break;

                case "C":
                case "c":
                    result = num1 * num2;
                    break;

                case "D":
                case "d":
                    result = num1 / num2;
                    break;
            }

            return result;
        }
    }
}