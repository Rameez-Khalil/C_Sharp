class program
{
    public static void Main(string[] args)
    {

        //EXPRESSION LAMBDA.
        var square = (int number) => number * number;

        Console.WriteLine("Square calculation : " + square(5));

        //STATEMENT LAMBDA.
        var addition = (int number1, int number2) =>
        {
            return number1 + number2;
        };

        Console.WriteLine("Addition result : " + addition(5,5));


        //USES OF LAMBDAS.
        //1. Passing parameter in method.
        int[] numbers = { 10, 20, 20, 30, 40 };

        var count = numbers.Count(x => x == 20);
        Console.WriteLine("Total count of : " + count);



    }
}


/*
 * Lambdas are syntactic sugar which can accept params and produce an output.
 * number=>number*7; 
 * 
 * We've two main types for lambdas: 1. Expression and 2. Statement.
 * 
 * 
 */