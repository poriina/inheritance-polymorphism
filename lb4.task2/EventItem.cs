using System;
using System.Collections.Generic;

public class EventItem
{
    private readonly string code;
    private string name;
    private double duration;

    private static int totalEventsCount = 0;

    public EventItem(string code, string name, double duration)
    {
        this.code = code;
        this.name = name;
        this.duration = duration;
        EventItem.totalEventsCount++;
    }

    public string Code { get { return this.code; } }
    public string Name { get { return this.name; } }
    public double Duration { get { return this.duration; } }

    public static int GetTotalEventsCount()
    {
        return EventItem.totalEventsCount;
    }

    public virtual string GetInfo()
    {
        Console.WriteLine($"викликано GetInfo() для {this.name}");
        return $"подія [{this.code}]: {this.name}, тривалість: {this.duration} годин";
    }

    public bool IsLongEvent()
    {
        Console.WriteLine($"викликано IsLongEvent() для {this.name}");
        return this.duration > 4.0;
    }

    public override string ToString()
    {
        Console.WriteLine($"викликано ToString() для {this.name}");
        return this.Name;
    }

    public override bool Equals(object obj)
    {
        if (obj is EventItem other)
            return this.code == other.code;
        return false;
    }

    public override int GetHashCode()
    {
        return this.code.GetHashCode();
    }
}

public class Conference : EventItem
{
    private int speakersCount;

    public Conference(string code, string name, double durationHours, int speakersCount)
            : base(code, name, durationHours)
    {
        this.speakersCount = speakersCount;
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $" | Тип: Конференція | Кількість спікерів: {this.speakersCount}";
    }
}

public class Workshop : EventItem
{
    private int seatsCount;

    public Workshop(string code, string name, double durationHours, int seatsCount)
        : base(code, name, durationHours)
    {
        this.seatsCount = seatsCount;
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $" | Тип: Майстер-клас | Кількість місць: {this.seatsCount}";
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("ствоерний список подій");
        List<EventItem> agencyEvents = new List<EventItem>();

        agencyEvents.Add(new Conference("C001", "IT 2026", 6.5, 12));
        agencyEvents.Add(new Workshop("D001", "Основи танцю", 3.0, 25));
        agencyEvents.Add(new Workshop("I001", "Історія України: скорочено", 5.0, 15));

        Console.WriteLine("\n інформація про івенти");
        double totalDuration = 0;
        int longEventsCount = 0;

        foreach (EventItem item in agencyEvents)
        {
            Console.WriteLine(item.GetInfo());

            totalDuration += item.Duration;
            if (item.IsLongEvent())
            {
                longEventsCount++;
            }
        }

        Console.WriteLine($"загальна кількість створених подій: {EventItem.GetTotalEventsCount()}");
        Console.WriteLine($"тривалість усіх подій: {totalDuration} годин");
        Console.WriteLine($"кількість тривалих подій (>4 годин): {longEventsCount}");

        Console.ReadLine();
    }
}