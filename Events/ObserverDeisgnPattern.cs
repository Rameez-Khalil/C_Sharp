const int threshold = 30000;

var emailPriceNotifier = new EmailPriceChangeNotifierOb(threshold);
var pushPriceNotifier = new PushPriceChangeNotifierOb(threshold);
var goldPriceReader = new GoldPriceReaderOb();


//attach the observers.
goldPriceReader.AttachObserver(emailPriceNotifier);
goldPriceReader.AttachObserver(pushPriceNotifier); 




for (int i = 0; i < 3; i++)
{
    goldPriceReader.ReadCurrentPrice();
}

//Turning push off.
Console.WriteLine("Turning push notifications off");
goldPriceReader.DetachObserver(pushPriceNotifier);

for (int i = 0; i < 3; i++)
{
    goldPriceReader.ReadCurrentPrice();
}


//THIS SENDS THE NOTIFICATION.
public class GoldPriceReaderOb : IObservable<int>
{
    private int _currentGoldPrice;
    private readonly List<IObserver<int>> _observers = new List<IObserver<int>>(); 

  

    public void ReadCurrentPrice()
    {
        _currentGoldPrice = new Random().Next(20000, 50000);
        NotifyObserver(); 
    


    }

    public void AttachObserver(IObserver<int> observer)
    {
        _observers.Add(observer);
    }

    public void DetachObserver(IObserver<int> observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObserver()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_currentGoldPrice); 
        }
    }
}


//NOTIFIER CLASS.
public class EmailPriceChangeNotifierOb : IObserver<int>
{
    private readonly int _notificationThreshold;

    public EmailPriceChangeNotifierOb(int notificationThreshold)
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


public class PushPriceChangeNotifierOb : IObserver<int>
{
    private readonly int _notificationThreshold;

    public PushPriceChangeNotifierOb(int notificationThreshold)
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



public interface IObserver<TData>
{
    void Update(TData data);
}



public interface IObservable<TData>
{
    void AttachObserver(IObserver<TData> observer);
    void DetachObserver(IObserver<TData> observer);

    void NotifyObserver(); //send notification to all subscriber.

}