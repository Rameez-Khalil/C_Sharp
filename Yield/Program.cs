class Program
{
    public static void Main(string[] args)
    {
        foreach (var item in getNumbers())
        {
            Console.WriteLine(item);
        }
    }


    public static IEnumerable<int> getNumbers()
    {
        var list = new List<int> { 1, 2, 3, 4, -10 };

        //iterate through the list.
        foreach (var i in list)
        {
            if (i > 0)
            {
                yield return i;
                Console.WriteLine("Returned item");
            }
            

            //this state will be preserved and the next time the function will be called from here.
            Console.WriteLine("Function stopped");
        }



    }
}
/*
 * YIELD - It performs custom iteration over a collection
 * yield return will return an expression at each iteration.
 * yield break terminates the iteration.
 * 
 * 
 * 
 */