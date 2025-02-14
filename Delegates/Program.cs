class program
{
    public static void Main(string[] args)
    {
        //create an instance.
        myDelegate sumDelegate = new myDelegate(calculateSum);

        Console.WriteLine(sumDelegate(5,5));

    }



    public delegate int myDelegate  (int a, int b); 
    public static int calculateSum(int x, int y) => x + y; 
}


/*
 * DELEGATE - A pointer to a method.
 */