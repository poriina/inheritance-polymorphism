using System;
using System.Collections.Generic;
public class Window
{
    public bool IsOpen { get; set; }
    public Window(bool isOpen=false)
    {
        IsOpen = isOpen;
        Console.WriteLine("[Window] викликано конструктор для створення вікна");
    }

    public void Open()
    {
        IsOpen=true;
        Console.WriteLine("викликано метод, що вікно відчинено");
    }

    public override string ToString()
    {
        return IsOpen ? "відчинене вікно" : "зачинене вікно";
    }
    public override bool Equals(object obj)
    {
        Console.WriteLine("викликано метод Equals().");
        if (obj is Window other)
            return this.IsOpen == other.IsOpen;
        return false;
    }

    public override int GetHashCode()
    {
        Console.WriteLine("викликано метод GetHashCode().");
        return IsOpen.GetHashCode();
    }
}

public class Door
{
    public bool IsLocked { get; private set; }

    public Door()
    {
        IsLocked = false;
        Console.WriteLine("викликано конструктор для створення двері.");
    }
    public void Lock()
    {
        IsLocked = true;
        Console.WriteLine("викликано метод, де двері закриті на ключ");
    }
    public override string ToString()
    {
        return IsLocked ? "замкнені двері" : "відчинені двері";
    }
    public override bool Equals(object obj)
    {
        Console.WriteLine("викликано метод Equals().");
        if (obj is Door other)
            return this.IsLocked == other.IsLocked;
        return false;
    }
    public override int GetHashCode()
    {
        return IsLocked.GetHashCode();
    }
}
    public class Home
    {
        private List<Window> windows;
        private List<Door> doors;
        public Home(int windows, int doors)
        {
            this.windows = new List<Window>();
            for (int i = 0; i < windows; i++)
            {
                this.windows.Add(new Window());
            }
            this.doors = new List<Door>();
            for (int i = 0; i < doors; i++)
            {
                this.doors.Add(new Door());
            }

            Console.WriteLine("будинок побудовано");
        }
    public void PrintCounts()
    {
        Console.WriteLine("викликано метод PrintCounts().");
        Console.WriteLine($"у цьому будинку {this.windows.Count} вікон та {this.doors.Count} дверей");
    }

    public void LockHouse()
    {
        foreach (var door in this.doors)
        {
            door.Lock();
        }

        Console.WriteLine("будинок закрито.");
    }
    public override string ToString()
    {
        return $"будинок ({this.windows.Count} вікон, {this.doors.Count} дверей)";
    }
    public override bool Equals(object obj)
    {
        Console.WriteLine("викликано метод Equals().");

        if (obj is Home other)
        {
            return this.windows.Count == other.windows.Count && this.doors.Count == other.doors.Count;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return this.windows.Count.GetHashCode() + this.doors.Count.GetHashCode();
    }
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; 

            Console.WriteLine("створення будинків");
            Home myHouse = new Home(4, 2);

            Console.WriteLine("\n для методів");
            myHouse.PrintCounts();
            myHouse.LockHouse();

            Console.WriteLine("\n перевірка порівняння");
            Home neighborHouse = new Home(4, 2);
            Console.WriteLine($"Чи однакові будинки за кількістю вікон/дверей? {myHouse.Equals(neighborHouse)}");

            Console.ReadLine(); 
        }
    }
}
