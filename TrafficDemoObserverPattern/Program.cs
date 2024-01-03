
Vehicle car = new Vehicle("Car");
Vehicle motorcycle = new Vehicle("Motorcycle");
Vehicle bus = new Vehicle("Bus");

TrafficLight trafficLight = new TrafficLight();

trafficLight.addObserver(car);
trafficLight.addObserver(motorcycle);
trafficLight.addObserver(bus);

Console.WriteLine("--------Light is Green---------");
trafficLight.changeColor(TrafficLightColor.Green);
Console.WriteLine("--------Light is Red---------");
trafficLight.changeColor(TrafficLightColor.Red);
Console.WriteLine("--------Light is Yellow---------");
trafficLight.changeColor(TrafficLightColor.Yellow);


class Vehicle : IObserver
{
    private readonly string _name;

    public Vehicle(string name)
    {
        _name = name;
    }
    public void Go()
    {
        Console.WriteLine($"{_name} start moving....");
    }
    public void Stop()
    {
        Console.WriteLine($"{_name} stop moving....");
    }
    public void Ready()
    {
        Console.WriteLine($"{_name} ready to moving....");
    }

    public void update(TrafficLightColor color)
    {
        if (color == TrafficLightColor.Red)
        {
            Stop();
        }
        else if (color == TrafficLightColor.Yellow)
        {
            Ready();
        }
        else
        {
            Go();
        }
    }
}

public enum TrafficLightColor
{
    Red,
    Yellow,
    Green
}

class TrafficLight : ISubject
{
    private List<IObserver> _observers;
    private TrafficLightColor _currentColor;

    public TrafficLight()
    {
        _observers = new List<IObserver>();
    }


    public void changeColor(TrafficLightColor color)
    {
        _currentColor = color;
        Console.WriteLine($"The current Light is {_currentColor}");
        notifyObservers();
    }

    public void addObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void removeObserver(IObserver observer)
    {
        _observers.Remove(observer);

    }

    public void notifyObservers()
    {
        foreach (var o in _observers)
        {
            o.update(_currentColor);
        }
    }
}

interface IObserver
{
    void update(TrafficLightColor color);
}

interface ISubject
{
    void addObserver(IObserver observer);
    void removeObserver(IObserver observer);
    void notifyObservers();
}
