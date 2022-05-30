namespace CsharpCalc
{
    internal class Program
    {
        public static void Main()
        {
            Console.Write("Enter first number: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int b = Convert.ToInt32(Console.ReadLine());

            int sum = Addition(a, b);

            Console.WriteLine("Sum is: " + sum);
        }

        private static int Addition(int a, int b)
        {
            return a + b;
        }
    }
}