using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Events; 



/*
 * EVENTS - They are the .NET implementaton of the observer design patterns.
 * They enable objects notify the other objects when something happens.
 * The mechanism of events is based off of delegates.
 * 
 * 
 * A variable of a delagate type can only be assigned a method with a signature described in the delegate.
 * 
 * Delegate are special types just like a struck or class.
 * A variable of type delegate can only be assigned a method with a signature described in the delegate.
 * 
 * 
 * 
 */

class Delegates
{

    public static void Main(string[] args)
    {
        int Test1(int number1, int number2) => number1 + number2;
        int Test11(int number1, int number2) => number1 + number2;
        int Test2(int number1, int number2, int number3) => number1 + number2+number3;


        //Adding more functions.
        AddTwo addTwo = Test1;
        addTwo += Test11;

        //Removing some functions.
        addTwo -= Test11; 
        

    }

    //defining the delegate.
    public  delegate int AddTwo(int number, int number2);
    public delegate int AddThree(int number, int number2, int number3);

    //adding more methods to a single delegate.
    
}

//THIS SENDS THE NOTIFICATION.
public delegate void PriceRead(int price); 
public class GoldPriceReader
{
    private int _currentGoldPrice;

    //event is always of a delegate type. 
    //Other classes must be able to access it. 

    public event PriceRead? PriceRead; 


   

    public GoldPriceReader()
    {
      
    }

    public void ReadCurrentPrice()
    {
        _currentGoldPrice = new Random().Next(20000, 50000);

        OnPriceRead(_currentGoldPrice); 
    }

    private void OnPriceRead(int price)
    {
        PriceRead(price); 

        PriceRead?.Invoke(price); //invokes all methods subscribed to the event. 
    }
}


//NOTIFIER CLASS.
public class EmailPriceChangeNotifier
{
    private readonly int _notificationThreshold;

    public EmailPriceChangeNotifier(int notificationThreshold)
    {
        _notificationThreshold = notificationThreshold;
    }


    //Update mechanism and send notification.
    public void Update(int price)
    {
        if (price > _notificationThreshold)
        {
            Console.WriteLine($"Sending an email saying " + $"the gold price has exceeded {_notificationThreshold}" + $" And it is now ${price}");
        }

    }
}


public class PushPriceChangeNotifier
{
    private readonly int _notificationThreshold;

    public PushPriceChangeNotifier(int notificationThreshold)
    {
        _notificationThreshold = notificationThreshold;
    }

    public void Update(int price)
    {
        if (price > _notificationThreshold)
        {
            Console.WriteLine($"Sending an push notification saying " + $"the gold price has exceeded {_notificationThreshold}" + $" And it is now ${price}");
        }
    }
}

class Program
{
    const int threshold = 30000; 
    public static void Main(string[] args)
    {
        var goldPrice = new GoldPriceReader();
        var emailPrice = new EmailPriceChangeNotifier(threshold);
        var pushPrice = new PushPriceChangeNotifier(threshold);


        goldPrice.PriceRead += emailPrice.Update;
        goldPrice.PriceRead += pushPrice.Update; 





    }
}





/*
 * EVENTS - Sending notifications from one object to another.
 * They cause memory leaks.
 * 
 * Many actions in our code should only be triggered as a reaction to some event.
 * 
 * 
 * In this example - Whenever there is a change in gold price, the push method should be executed from both classes.
 * 
 * 
 * OBSERVER DESIGN PATTERN - This pattern allows objects to notify other objects about changes in their state.
 * In order to implement this, we identify which are the classes that are observable(being observed) and which ones are observer.
 * 
 * GoldPrice - Observable.
 * NotificationsClasses - Observers.
 * 
 * 1. First decouple them and define an interface over which they can communicate.
 */