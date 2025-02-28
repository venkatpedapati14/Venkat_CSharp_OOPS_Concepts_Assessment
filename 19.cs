using System;
using System.Collections.Generic;

interface INotificationObserver
{
    void Update(string message);
}

class EmailNotifier : INotificationObserver
{
    public void Update(string message)
    {
        Console.WriteLine("Email Notification: " + message);
    }
}

class SMSNotifier : INotificationObserver
{
    public void Update(string message)
    {
        Console.WriteLine("SMS Notification: " + message);
    }
}

class NotificationService
{
    private List<INotificationObserver> observers = new List<INotificationObserver>();

    public void Subscribe(INotificationObserver observer)
    {
        observers.Add(observer);
        Console.WriteLine(observer.GetType().Name + " subscribed.");
    }

    public void Unsubscribe(INotificationObserver observer)
    {
        if (observers.Remove(observer))
        {
            Console.WriteLine(observer.GetType().Name + " unsubscribed.");
        }
    }

    public void Notify(string message)
    {
        Console.WriteLine("\nSending Notification: " + message);
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }
}