using System;

public class Time
{
    public int hours;
    public int minutes;
    public int seconds;

    public Time(int hours, int minutes, int seconds)
    {
        this.hours = hours;
        this.minutes = minutes;
        this.seconds = seconds;
    }

    public int differenceInSeconds(Time other)
    {
        int totalSecondsThis = hours * 3600 + minutes * 60 + seconds;
        int totalSecondsOther = other.hours * 3600 + other.minutes * 60 + other.seconds;
        return Math.Abs(totalSecondsThis - totalSecondsOther);
    }

    public Time addSeconds(int secondsToAdd)
    {
        int totalSeconds = hours * 3600 + minutes * 60 + seconds + secondsToAdd;
        int newHours = totalSeconds / 3600;
        int newMinutes = (totalSeconds % 3600) / 60;
        int newSeconds = totalSeconds % 60;
        return new Time(newHours, newMinutes, newSeconds);
    }

    public Time subtractSeconds(int secondsToSubtract)
    {
        int totalSeconds = hours * 3600 + minutes * 60 + seconds - secondsToSubtract;
        if (totalSeconds < 0)
        {
            throw new ArgumentException("Время не может быть отрицательным");
        }
        int newHours = totalSeconds / 3600;
        int newMinutes = (totalSeconds % 3600) / 60;
        int newSeconds = totalSeconds % 60;
        return new Time(newHours, newMinutes, newSeconds);
    }

    public bool isBefore(Time other)
    {
        int totalSecondsThis = hours * 3600 + minutes * 60 + seconds;
        int totalSecondsOther = other.hours * 3600 + other.minutes * 60 + other.seconds;
        return totalSecondsThis < totalSecondsOther;
    }

    public bool isAfter(Time other)
    {
        int totalSecondsThis = hours * 3600 + minutes * 60 + seconds;
        int totalSecondsOther = other.hours * 3600 + other.minutes * 60 + other.seconds;
        return totalSecondsThis > totalSecondsOther;
    }

    public int toSeconds()
    {
        return hours * 3600 + minutes * 60 + seconds;
    }

    public double toMinutes()
    {
        return (int)toSeconds() / 60;
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
        Time time1 = new Time(hours, minutes, seconds);

        Console.Write("Введите часы для второго времени: ");
        hours = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите минуты для второго времени: ");
        minutes = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите секунды для второго времени: ");
        seconds = Convert.ToInt32(Console.ReadLine());
        Time time2 = new Time(hours, minutes, seconds);

        Console.WriteLine("Разница в секундах: " + time1.differenceInSeconds(time2));
        Console.WriteLine("Введите количество секунд которое хотите добавить в первое время");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите количество секунд которое хотите отнять в первом времени");
        int b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите количество секунд которое хотите добавить во второе время");
        int c = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите количество секунд которое хотите отнять во втором времени");
        int d = Convert.ToInt32(Console.ReadLine());
        Time time3 = time1.addSeconds(a);
        Console.WriteLine("После добавления 120 секунд(1 число): " + time3.hours + ":" + time3.minutes + ":" + time3.seconds);

        Time time4 = time1.subtractSeconds(b);
        Console.WriteLine("После вычитания 120 секунд(1 число): " + time4.hours + ":" + time4.minutes + ":" + time4.seconds);

        Time time5 = time2.addSeconds(c);
        Console.WriteLine("После добавления 120 секунд(2 число): " + time5.hours + ":" + time5.minutes + ":" + time5.seconds);

        Time time6 = time2.subtractSeconds(d);
        Console.WriteLine("После вычитания 120 секунд(2 число): " + time6.hours + ":" + time6.minutes + ":" + time6.seconds);

        Console.WriteLine("Время в секундах(1 число): " + time1.toSeconds());
        Console.WriteLine("Время в минутах(1 число): " + time1.toMinutes());
        Console.WriteLine("Время в секундах(2 число): " + time2.toSeconds());
        Console.WriteLine("Время в минутах(2 число): " + time2.toMinutes());
    }
}
