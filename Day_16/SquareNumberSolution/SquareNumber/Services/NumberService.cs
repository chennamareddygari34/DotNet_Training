using SquareNumberApi.Interfaces;



namespace SquareNumberApi.Services
{
    public class NumberService : INumberService

    {
      public List<int> NumbersWithSquares(List<int> numbers)

        {
           var numbersSquares = new List<int>();

            foreach (var i in numbers)

            {

                var square = i * i;



                if (numbers.Contains(square))

                {
                    numbersSquares.Add(i);
                }
            }

                return numbersSquares;

        }

    }
}