using System;

class Program
{
    private static Random random = new Random();

    static string GetRandomTime()
    {
        int hours = random.Next(0, 24);
        int minutes = random.Next(0, 60);
        int seconds = random.Next(0, 60);
        
        return $"{hours:D2}{minutes:D2}{seconds:D2}";
    }

    static void Main(string[] args)
    {
        string time = GetRandomTime();
        Console.WriteLine(time);
    }
}