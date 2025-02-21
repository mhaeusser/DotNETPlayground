public class Publisher
{
    public event EventHandler OnEvent;

    public void TriggerEvent() => OnEvent?.Invoke(this, EventArgs.Empty);
}

public class Subscriber
{
    public void HandleEvent(object sender, EventArgs e)
    {
        Console.WriteLine("Event triggered!");
    }
}

public class EventsAndDelegates
{
    static void Main()
    {
        Publisher publisher = new Publisher();
        Subscriber subscriber = new Subscriber();
        
        publisher.OnEvent += subscriber.HandleEvent;
        publisher.TriggerEvent();  // Output: Event triggered!
    }
}
