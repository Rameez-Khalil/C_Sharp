using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ;

public class Program
{

    public static void Main(string[] args)
    {
        string[] stringArray = { "Rameez", "KHALIL" };
        var output = isUpperCaseLinq(stringArray);
        Console.WriteLine(output);

        //METHOD CHAINING.
        int[] numbers = { 50, 3, 7, 1 };
        var orderedResults = sortedOddNumbers(numbers);
        Console.WriteLine("METHOD CHAINING : " + string.Join(",",orderedResults));

        //DEFERRED EXECUTION.
        string[] stringArray2 = { "AA", "AAAA" };
        shortWords(stringArray2);

        //FILTER (WHERE AND DISTINCT)
        int[] numsArray = { 10, 20, 30, 40,40,41 };
        var evenNumbers = numsArray.Where(number => number % 2 == 0).Distinct();
        Console.WriteLine(string.Join(",", evenNumbers));

        //SELECT PROJECTS EACH OBJECT INTO A NEW FORM.

        int[] numbersArr ={ 10, 20, 30, 40 };
        var doubledNumbers = numbersArr.Select(number => number * 2);
        Console.WriteLine(string.Join("", doubledNumbers));



    }


    public static bool isUpperCase(IEnumerable<string> words)
    {
        //read each word from the provided string.
        foreach (var word in words) {
            //for every letter identify if its an uppercase or !.

            bool upperCase = true; 

            foreach(var letter in word)
            {
                if(char.IsLower(letter)) upperCase = false;

            }

            if (upperCase) { 
                return true;
            }


        }

        return false;

    }

    //LINQ version.
    public static bool isUpperCaseLinq(IEnumerable<string> words) {
        return words
            .Any(word => word.All(letter => char.IsUpper(letter))); 
    }

    public static IEnumerable<int> sortedOddNumbers(IEnumerable<int> numbers)
    {
        return numbers
            .Where(number => number % 2 != 0)
            .OrderBy(number => number); 
    }

    public static IEnumerable<string> shortWords(IEnumerable<string> words)
    {


        //read each word and then return where the length < 3.
        words = words.Where(word => word.Length < 3);
        Console.WriteLine(words);
        words.Append("EE");


        Console.WriteLine(string.Join(",", words.Where(word => word.Length < 3)));

        return words.Where(word => word.Length < 3);

    }
}


/*
 * LINQ  - language integrated query.
 * It allows filtering, ordering and transforming the collection elements, they cannot modify the collections
 * 
 * HOW CAN THE SAME LINQ METHOD WORK ON DIFFERENT DATA TYPES.
 *  LINQ METHODS ARE DEFINED UNDER PARTIAL CLASS OF ENUMERABLE AND ACCEPTS IENUMERABLE TYPE.
 *  
 *  
 *  IENUMERABLE INTERFACE - Source for almost all collections, this is the reason we can iterate collections using foreach loop.
 *  Since LINQ takes an IEnumerable and procudes the same result, we can chain multiple methods.
 *  
 *  
 *  //DEFERRED EXECUTION - Evaluation is delayed until the value is actually required.
 *  
 *  COMMON METHODS
 *  //Any - It checks if any element matches the criteria.
 *  //All - It checks if all elements match the criteria.
 *  //Count - Counts based off of the matching criteria
 *  //Contains - Checks if an item contains something based off of the criteria.
 *  //First and last - They provide first and last element in the provided collection.
 *  
 *  //FILTER (WHERE).
 *  
 *  
 *  
 *  
 *  
 *  
 *  
 */