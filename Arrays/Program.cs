namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declare and initialize an array
            int[] numbers = { 5, 3, 8, 1, 2 };

            // Print original array
            Console.WriteLine("Original Array:");
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
            // or

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    Console.WriteLine(numbers[i]);
            //}

            // Access and modify array elements
            numbers[0] = 10; // Change the first element to 10

            // Print modified array
            Console.WriteLine("Modified Array:");
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();

            // Sort the array in ascending order
            Array.Sort(numbers);

            // Print sorted array
            Console.WriteLine("Sorted Array:");
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();

            // Reverse the array
            Array.Reverse(numbers);

            // Print reversed array
            Console.WriteLine("Reversed Array:");
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
}
