class Program
{

    public static void Main(string[] args)
    {

    }


    //get even numbers.
    public IEnumerable<int> getEvenNumbers(IEnumerable<int> numbers)
    {
        numbers = numbers.Where(number => number % 2 == 0); 
        return numbers.ToList();
    }

    //get max number.
    public static int GetMaxNumber(IEnumerable<int> numbers)
    {
        return numbers.Max(); 
    }

    //square each number in the list.
    public static IEnumerable<int> SquareEachNumber(IEnumerable<int> numbers)
    {
        return numbers.Select(number => number *number); 
    }

    //Count numbers greater than the provided value.
    public static int CountGreaterNumbers(IEnumerable<int> numbers, int value) 
    {
        return numbers.Count(number=>number > value);
    }
}





