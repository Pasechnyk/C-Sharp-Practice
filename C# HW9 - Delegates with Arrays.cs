using System;

namespace Delegates
{
    // Task - create several arrays with different conditions using delegate system
    delegate int ArrayInitializer(int value);

    class Program
    {
        // delegate methods
        public static void Initialize (int[] arr, Func<int, int> init)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = init(i);
            }
        }

        public static void ModifyArray(int[] arr, ArrayInitializer init)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = init(arr[i]);
            }
        }

        // method with Fibonacci numbers
        public static int Fibonacci(int value)
        {
            int firstNumber = 0, secondNumber = 1, result = 0;
            if (value == 0)
                return 0;
            if (value == 1)
                return 1;
            for (int i = 2; i <= value; i++)
            {
                result = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = result;
            }
            return result;

        }

        // show array
        public static void ShowArray(int[] arr, string text)
        {
            Console.Write($"{text}: ");
            foreach (var i in arr)
            {
                Console.Write(i + " ");
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            // anonymous delegate methods
            // random values
            int[] num1 = new int[15];
            Initialize(num1, (i) => new Random().Next(100));
            ShowArray(num1, "Array with RANDOM values:");

            // values of 2 decree
            int[] num2 = new int[10];
            Initialize(num2, (i) => (int)Math.Pow(2, i));
            ShowArray(num2, "Array with 2 in DECREE:");

            // values of numbers multiplied by 3
            int[] num3 = new int[20];
            Initialize(num3, (i) => i * 3);
            ShowArray(num3, "Array with numbers MULTIPLIED by 3:");

            // using delegate as method parameter
            // Fibonacci numbers
            int[] num4 = new int[20];
            ModifyArray(num4, Fibonacci);
            ShowArray(num4, "Array with FIBONACCI numbers:");

        }
    }
}
