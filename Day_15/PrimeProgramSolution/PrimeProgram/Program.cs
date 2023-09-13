namespace PrimeProgram
{
    class Program
    {
        // Function to check if a number is prime
        static bool IsPrime(int number)
        {
            if (number <= 1)
                return false;
            if (number <= 3)
                return true;
            if (number % 2 == 0 || number % 3 == 0)
                return false;



            for (int i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                    return false;
            }



            return true;
        }



        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers. Enter 0 to stop.");



            int[] numbers = new int[100]; // Assuming a maximum of 100 numbers
            int count = 0;



            while (true)
            {
                Console.Write("Enter a number: ");
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    if (number == 0)
                        break;



                    numbers[count] = number;
                    count++;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }



            Console.WriteLine("Prime numbers entered:");



            for (int i = 0; i < count; i++)
            {
                if (IsPrime(numbers[i]))
                {
                    Console.WriteLine(numbers[i]);
                }
            }
        }
    }
}