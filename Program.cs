using System;


public interface ITime
{
    int Hours { get; set; }
    int Minutes { get; set; }
    int Seconds { get; set; }

    int DifferenceInSeconds(ITime other);
    ITime AddSeconds(int secondsToAdd);
    ITime SubtractSeconds(int secondsToSubtract);
    bool IsBefore(ITime other);
    bool IsAfter(ITime other);
    int ToSeconds();
    double ToMinutes();
}

public abstract class AbstractTime : ITime
{
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public int Seconds { get; set; }

    public AbstractTime(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
    }

    public int DifferenceInSeconds(ITime other)
    {
        int totalSecondsThis = Hours * 3600 + Minutes * 60 + Seconds;
        int totalSecondsOther = other.Hours * 3600 + other.Minutes * 60 + other.Seconds;
        return Math.Abs(totalSecondsThis - totalSecondsOther);
    }

    public ITime AddSeconds(int secondsToAdd)
    {
        int totalSeconds = Hours * 3600 + Minutes * 60 + Seconds + secondsToAdd;
        int newHours = totalSeconds / 3600;
        int newMinutes = (totalSeconds % 3600) / 60;
        int newSeconds = totalSeconds % 60;
        return new Time(newHours, newMinutes, newSeconds);
    }

    public ITime SubtractSeconds(int secondsToSubtract)
    {
        int totalSeconds = Hours * 3600 + Minutes * 60 + Seconds - secondsToSubtract;
        if (totalSeconds < 0)
        {
            throw new ArgumentException("Время не может быть отрицательным");
        }
        int newHours = totalSeconds / 3600;
        int newMinutes = (totalSeconds % 3600) / 60;
        int newSeconds = totalSeconds % 60;
        return new Time(newHours, newMinutes, newSeconds);
    }

    public bool IsBefore(ITime other)
    {
        int totalSecondsThis = Hours * 3600 + Minutes * 60 + Seconds;
        int totalSecondsOther = other.Hours * 3600 + other.Minutes * 60 + other.Seconds;
        return totalSecondsThis < totalSecondsOther;
    }

    public bool IsAfter(ITime other)
    {
        int totalSecondsThis = Hours * 3600 + Minutes * 60 + Seconds;
        int totalSecondsOther = other.Hours * 3600 + other.Minutes * 60 + other.Seconds;
        return totalSecondsThis > totalSecondsOther;
    }

    public int ToSeconds()
    {
        return Hours * 3600 + Minutes * 60 + Seconds;
    }

    public double ToMinutes()
    {
        return (int)ToSeconds() / 60;
    }
}


public class Time : AbstractTime
{
    public Time(int hours, int minutes, int seconds) : base(hours, minutes, seconds)
    {
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Введите часы: ");
        int hours = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите минуты: ");
        int minutes = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите секунды: ");
        int seconds = Convert.ToInt32(Console.ReadLine());
        ITime time1 = new Time(hours, minutes, seconds);

        Console.Write("Введите часы для второго времени: ");
        hours = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите минуты для второго времени: ");
        minutes = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите секунды для второго времени: ");
        seconds = Convert.ToInt32(Console.ReadLine());
        ITime time2 = new Time(hours, minutes, seconds);

        Console.WriteLine("Разница в секундах: " + time1.DifferenceInSeconds(time2));
        Console.WriteLine("Введите количество секунд которое хотите добавить в первое время");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите количество секунд которое хотите отнять в первом времени");
        int b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите количество секунд которое хотите добавить во второе время");
        int c = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите количество секунд которое хотите отнять во втором времени");
        int d = Convert.ToInt32(Console.ReadLine());
        ITime time3 = time1.AddSeconds(a);
        Console.WriteLine("После добавления 120 секунд(1 число): " + time3.Hours + ":" + time3.Minutes + ":" + time3.Seconds);

        ITime time4 = time1.SubtractSeconds(b);
        Console.WriteLine("После вычитания 120 секунд(1 число): " + time4.Hours + ":" + time4.Minutes + ":" + time4.Seconds);

        ITime time5 = time2.AddSeconds(c);
        Console.WriteLine("После добавления 120 секунд(2 число): " + time5.Hours + ":" + time5.Minutes + ":" + time5.Seconds);

        ITime time6 = time2.SubtractSeconds(d);
        Console.WriteLine("После вычитания 120 секунд(2 число): " + time6.Hours + ":" + time6.Minutes + ":" + time6.Seconds);

        Console.WriteLine("Время в секундах(1 число): " + time1.ToSeconds());
        Console.WriteLine("Время в минутах(1 число): " + time1.ToMinutes());
        Console.WriteLine("Время в секундах(2 число): " + time2.ToSeconds());
        Console.WriteLine("Время в минутах(2 число): " + time2.ToMinutes());
    }
}
