//const int threshold = 30000; 

//var emailPriceNotifier = new EmailPriceChangeNotifier(threshold);
//var pushPriceNotifier = new PushPriceChangeNotifier(threshold);
//var goldPriceReader = new GoldPriceReader(emailPriceNotifier, pushPriceNotifier); 

//for(int i = 0; i < 3; i++)
//{
//    goldPriceReader.ReadCurrentPrice();
//}


////THIS SENDS THE NOTIFICATION.
//public class GoldPriceReader
//{
//    private int _currentGoldPrice;

//    private readonly EmailPriceChangeNotifier _emailNotifier;
//    private readonly PushPriceChangeNotifier _pushNotifier;

//    public GoldPriceReader(EmailPriceChangeNotifier emailNotifier, PushPriceChangeNotifier pushNotifier)
//    {
//        _emailNotifier = emailNotifier;
//        _pushNotifier = pushNotifier;
//    }

//    public void ReadCurrentPrice() 
//    { 
//       _currentGoldPrice = new Random().Next(20000,50000);
//        _emailNotifier.Update(_currentGoldPrice); 
//        _pushNotifier.Update(_currentGoldPrice);


//    }


//}


////NOTIFIER CLASS.
//public class EmailPriceChangeNotifier
//{
//    private readonly int _notificationThreshold;

//    public EmailPriceChangeNotifier(int notificationThreshold)
//    {
//        _notificationThreshold = notificationThreshold;
//    }


//    //Update mechanism and send notification.
//    public void Update(int price)
//    {
//        if (price > _notificationThreshold)
//        {
//            Console.WriteLine($"Sending an email saying " + $"the gold price has exceeded {_notificationThreshold}" + $" And it is now ${price}");
//        }

//    }
//}


//public class PushPriceChangeNotifier
//{
//    private readonly int _notificationThreshold;

//    public PushPriceChangeNotifier(int notificationThreshold)
//    {
//        _notificationThreshold = notificationThreshold;
//    }

//    public void Update(int price) {
//        if (price > _notificationThreshold)
//        {
//            Console.WriteLine($"Sending an push notification saying " + $"the gold price has exceeded {_notificationThreshold}" + $" And it is now ${price}");
//        }
//    }
//}





///*
// * EVENTS - Sending notifications from one object to another.
// * They cause memory leaks.
// * 
// * Many actions in our code should only be triggered as a reaction to some event.
// * 
// * 
// * In this example - Whenever there is a change in gold price, the push method should be executed from both classes.
// * 
// * 
// * OBSERVER DESIGN PATTERN - This pattern allows objects to notify other objects about changes in their state.
// * In order to implement this, we identify which are the classes that are observable(being observed) and which ones are observer.
// * 
// * GoldPrice - Observable.
// * NotificationsClasses - Observers.
// * 
// * 1. First decouple them and define an interface over which they can communicate.
// */